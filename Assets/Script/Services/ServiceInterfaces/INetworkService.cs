﻿using System;
using System.Threading.Tasks;

public interface INetworkService
{
    // return code
    //  login and sign in
    //      400 ok
    //      401 error_email_format
    //      402 login_email_unauthorized
    //      403 login_authentication_failure
    //      404 login_error
    //      405 sign_in_email_authorized
    //      406 sign_in_username_exist
    //  notification
    //      501 ready_state

    string _serverIp { get; set; }
    int _serverPort { get; set; }
    void InitializeNetworkService(string serverIp, int serverPort);
    Task<int> Login(string email, string password);
    Task<int> SignIn(string email, string username, string password);
    Task<string> RpcCall(string rpcName, string payload = null, bool unauthorized = false);
    Task<bool> StartMatchMaker(int matchType, int playerCount);
    Task<bool> StopMatchMaker();
    Task<bool> JoinMatch();
    Task<bool> SendMatchData(long dataCode, string payload);
}