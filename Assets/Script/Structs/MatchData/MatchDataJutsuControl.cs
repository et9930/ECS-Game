using System.Runtime.Serialization;

[DataContract]
public class MatchDataJutsuControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "oid")] public string originatorId;
    [DataMember(Name = "jname")] public string jutsuName;
    [DataMember(Name = "needt")] public bool needTarget;
    [DataMember(Name = "tid")] public string targetId;
}