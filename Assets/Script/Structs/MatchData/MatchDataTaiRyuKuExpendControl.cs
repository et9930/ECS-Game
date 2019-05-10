using System.Runtime.Serialization;

[DataContract]
public class MatchDataTaiRyuKuExpendControl : IMatchData
{
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "texpend")] public float taiRyuKuExpend;
}