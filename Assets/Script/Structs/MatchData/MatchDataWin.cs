using System.Runtime.Serialization;

[DataContract]
public class MatchDataWin : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "win")] public int winTeam;
}