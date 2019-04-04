using System;
using System.Threading.Tasks;
using Nakama;

public class NakamaNetworkService : INetworkService
{
    private IClient _client;
    private ISession _session;
    private const string _serverKey = "NarutoKey";
    private const string _httpKey = "NarutoKey";
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
        _client = new Client(_serverKey, serverIp, serverPort);
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
        return 400;
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
                apiRpc = await _client.RpcAsync(_httpKey, rpcName, payload);
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
}