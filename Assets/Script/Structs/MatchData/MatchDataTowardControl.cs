using System.Runtime.Serialization;

[DataContract]
public class MatchDataTowardControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "left")] public bool faceLeft;
}