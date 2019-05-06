using System.Runtime.Serialization;

[DataContract]
public class MatchDataMovementControl : IMatchData
{
    [DataMember(Name = "user_id")] public string userId;
    [DataMember(Name = "horizontal")] public float horizontal;
    [DataMember(Name = "vertical")] public float vertical;
}