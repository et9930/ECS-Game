using System.Threading.Tasks;

public interface INetworkService
{
    // return code
    // 400 ok
    // 401 error_email_format
    // 402 login_email_unauthorized
    // 403 login_authentication_failure
    // 404 login_other_error
    // 405 sign_in_email_authorized
    // 406 sign_in_other_error
    // 407 ping_error

    string _serverIp { get; set; }
    int _serverPort { get; set; }
    void InitializeNetworkService(string serverIp, int serverPort);
    Task<int> Login(string email, string password);
    Task<int> SignIn(string email, string username, string password);
    Task<int> Ping();
    Task<string> RpcCall(string rpcName, string payload);
}