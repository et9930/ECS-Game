using System.Runtime.Serialization;

[DataContract]
public class ServerConfig
{
    [DataMember] public string ip;
    [DataMember] public int port;
}