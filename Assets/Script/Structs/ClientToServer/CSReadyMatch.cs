using System.Runtime.Serialization;

[DataContract]
public class CSReadyMatch : ICSMessage
{
    [DataMember(Name = "ready")] public bool ready;
}