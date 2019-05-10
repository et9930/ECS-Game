using System.Runtime.Serialization;

[DataContract]
public class MatchDataTowardControl : IMatchData
{
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "left")] public bool faceLeft;
}