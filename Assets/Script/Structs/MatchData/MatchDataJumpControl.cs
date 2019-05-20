using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class MatchDataJumpControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    /// <summary>
    /// 0:Start, 1:Cancel, 2:Jump
    /// </summary>
    [DataMember(Name = "state")] public int state;
    [DataMember(Name = "force")] public Vector3 force;
}