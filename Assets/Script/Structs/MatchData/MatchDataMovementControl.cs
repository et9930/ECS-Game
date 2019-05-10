using System.Runtime.Serialization;

[DataContract]
public class MatchDataMovementControl : IMatchData
{
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "h")] public float horizontal;
    [DataMember(Name = "v")] public float vertical;
}