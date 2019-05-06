using Entitas;

[Game]
public class SendToServerComponent : IComponent
{
    public string rpcName;
    public string payload;
    public bool unauthorized;
}