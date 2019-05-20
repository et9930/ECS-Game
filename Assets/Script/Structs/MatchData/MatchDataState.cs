using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class MatchDataState : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "a")] public Vector3 acceleration;
    [DataMember(Name = "v")] public Vector3 velocity;
    [DataMember(Name = "p")] public Vector3 position;

    [DataMember(Name = "ccurrent")] public float currentChaKuRa;
    [DataMember(Name = "tcurrent")] public float currentTaiRyoKu;
    [DataMember(Name = "hcurrent")] public float currentHealth;
}