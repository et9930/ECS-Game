using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class SCMatchData
{
    [DataMember(Name = "custom_match_id")] public string customMatchId;
    [DataMember(Name = "match_player")]    public List<MatchPlayer> matchPlayers;
    [DataMember(Name = "match_type")]      public int matchType;
    [DataMember(Name = "match_size")]      public int matchSize;
    [DataMember(Name = "match_ready_number")] public int matchReadyNumber;
    [DataMember(Name = "match_choose_finish_number")] public int matchChooseFinishNumber;
    [DataMember(Name = "match_random_seed")] public int matchRandomSeed;
}

[DataContract]
public class MatchPlayer
{
    [DataMember(Name = "user_id")] public string userId;
    [DataMember(Name = "team")]    public int team;
    [DataMember(Name = "position")] public int position;
    [DataMember(Name = "ninja_name")] public string ninjaName;
}