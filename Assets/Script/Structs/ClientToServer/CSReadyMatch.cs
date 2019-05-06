using System.Runtime.Serialization;

[DataContract]
public class CSReadyMatch
{
    [DataMember(Name = "ready")] public bool ready;
}