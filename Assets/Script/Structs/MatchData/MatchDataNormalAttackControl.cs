using System.Runtime.Serialization;

[DataContract]
public class MatchDataNormalAttackControl : IMatchData
{
    [DataMember(Name = "user_id")] public string userId;
    [DataMember(Name = "attack_index")] public int attackIndex;
    [DataMember(Name = "immediately")] public bool immediately;
}