using System.Runtime.Serialization;

[DataContract]
public class MatchDataMakeChaKuRaControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "is")] public bool isMakingChaKuRa;
}