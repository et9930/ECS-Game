using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class MatchDataNormalAttackControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "p")] public Vector3 position;
    [DataMember(Name = "idx")] public int attackIndex;
    [DataMember(Name = "imme")] public bool immediately;
}