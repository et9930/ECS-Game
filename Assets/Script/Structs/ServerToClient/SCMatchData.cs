using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class SCMatchData
{
    [DataMember(Name = "custom_match_id")] public string customMatchId;
    [DataMember(Name = "match_player")]    public List<MatchPlayer> matchPlayers;
    [DataMember(Name = "match_type")]      public int matchType;
    [DataMember(Name = "match_size")]      public int matchSize;
}

[DataContract]
public class MatchPlayer
{
    [DataMember(Name = "user_id")] public string userId;
    [DataMember(Name = "team")]    public int team;
}