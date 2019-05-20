using System.Runtime.Serialization;

[DataContract]
public class MatchDataTaiRyuKuExpendControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "texpend")] public float taiRyuKuExpend;
}