using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Nakama;
using UnityEngine;
using UnityEngine.UI;

public class NakamaNetworkService : INetworkService
{
    private IClient _client;
    private ISocket _socket;
    private ISession _session;
    private IMatchmakerTicket _matchmakerTicket;
    private IMatchmakerMatched _matchmakerMatched;
    private IMatch _match;
    private const string ServerKey = "NarutoKey";
    private const string HttpKey = "NarutoKey";
    private readonly GameContext _context;

    public string _serverIp { get; set; }
    public int _serverPort { get; set; }

    public NakamaNetworkService()
    {
        _context = Contexts.sharedInstance.game;
    }

    public void InitializeNetworkService(string serverIp, int serverPort)
    {
        _serverIp = serverIp;
        _serverPort = serverPort;
        _client = new Client(ServerKey, serverIp, serverPort);
    }

    public async Task<int> Login(string email, string password)
    {
        try
        {
            _session = await _client.AuthenticateEmailAsync(email, password, null, false);
        }
        catch (ApiResponseException e)
        {
            switch (e.Message)
            {
                case "Invalid email address format.":
                    return 401;
                case "User account not found.":
                    return 402;
                case "Invalid credentials.":
                    return 403;
                default:
                    return 404;
            }
        }
        _context.ReplaceCurrentPlayerId(_session.UserId);

        // create socket
        _socket = _client.CreateWebSocket();
        await _socket.ConnectAsync(_session);

        // set socket event
        _socket.OnMatchmakerMatched += OnMatchmakerMatched;
        _socket.OnMatchState += OnMatchState;
        _socket.OnNotification += OnNotification;

        return 400;
    }

    private void OnNotification(object sender, IApiNotification notification)
    {
        switch (notification.Code)
        {
            case 501:
                var matchReadyState = Utilities.ParseJson<SCReadyState>(notification.Content);
                if (matchReadyState.customMatchId == _context.currentMatchData.value.customMatchId)
                {
                    _context.CreateEntity().ReplaceMatchReadyState(matchReadyState);
                }
                break;
            case 502:
                var allocationNinja = Utilities.ParseJson<SCAllocationNinja>(notification.Content);
                _context.ReplaceAllocationNinjaNotification(allocationNinja);
                break;
            case 503:
                var chooseNinja = Utilities.ParseJson<SCChooseNinja>(notification.Content);
                _context.CreateEntity().ReplacePlayerChooseNinjaInfo(chooseNinja.userId, chooseNinja.ninjaName,chooseNinja.confirm);
                break;
            case 504:
                var matchData = Utilities.ParseJson<SCMatchData>(notification.Content);
                _context.ReplaceCurrentMatchData(matchData);
                _context.isMatchStart = true;
                break;
            default:
                break;
        }
    }

    private void OnMatchState(object sender, IMatchState state)
    {
        var payload = System.Text.Encoding.UTF8.GetString(state.State);
        _context.CreateEntity().ReplaceMatchData(state.OpCode, payload);
    }

    private void OnMatchmakerMatched(object sender, IMatchmakerMatched matched)
    {
        _context.CreateEntity().ReplaceDebugMessage("On Matchmaker Matched");
        _matchmakerMatched = matched;
        _context.isGameMatched = true;
    }
    
    public async Task<int> SignIn(string email, string username, string password)
    {
        try
        {
            _session = await _client.AuthenticateEmailAsync(email, password, username, true);
        }
        catch (ApiResponseException e)
        {
            switch (e.Message)
            {
                case "Invalid email address format.":
                    return 401;
                default:
                    return 406;
            }
        }

        if (_session == null || _session.Username != username || !_session.Created)
        {
            return 405;
        }

        return 400;
    }

    public async Task<string> RpcCall(string rpcName, string payload = null, bool unauthorized = false)
    {
        string rpcPayload;
        try
        {
            IApiRpc apiRpc = null;
            if (unauthorized)
            {
                apiRpc = await _client.RpcAsync(HttpKey, rpcName, payload);
            }
            else
            {
                apiRpc = await _client.RpcAsync(_session, rpcName, payload);
            }
            rpcPayload = apiRpc.Payload;
        }
        catch (Exception)
        {
            return null;
        }

        return rpcPayload;
    }

    public async Task<bool> StartMatchMaker(int matchType, int playerCount)
    {
        var minCount = playerCount;
        var maxCount = playerCount;
        var numericProperties = new Dictionary<string, double>() {
            {"matchType", matchType}
        };
        string query;
        switch (matchType)
        {
            case 0:
                query = "*";
                break;
            case 1:
                query = "-properties.matchType:2 -properties.matchType:3";
                break;
            case 2:
                query = "-properties.matchType:1 -properties.matchType:3";
                break;
            case 3:
                query = "-properties.matchType:1 -properties.matchType:2";
                break;
            default:
                query = "*";
                break;
        }

        try
        {
            _matchmakerTicket = await _socket.AddMatchmakerAsync(query, minCount, maxCount, null, numericProperties);
            
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> StopMatchMaker()
    {
        try
        {
            await _socket.RemoveMatchmakerAsync(_matchmakerTicket);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> JoinMatch()
    {
        try
        {
            _match = await _socket.JoinMatchAsync(_matchmakerMatched);
            _context.isAllPlayerJoined = true;
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> SendMatchData(long dataCode, string payload)
    {
        try
        {
            await _socket.SendMatchStateAsync(_match.Id, dataCode, payload);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message + "\n" + e.StackTrace);
            return false;
        }

        return true;
    }
}