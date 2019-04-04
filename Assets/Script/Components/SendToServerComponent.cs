using Entitas;

[Game]
public class SendToServerComponent : IComponent
{
    public string rpcName;
    public ICSMessage payload;
    public bool unauthorized;
}