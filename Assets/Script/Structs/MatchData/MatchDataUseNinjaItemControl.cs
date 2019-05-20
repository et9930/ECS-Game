using System.Runtime.Serialization;

[DataContract]
public class MatchDataUseNinjaItemControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "item")] public string item;
}