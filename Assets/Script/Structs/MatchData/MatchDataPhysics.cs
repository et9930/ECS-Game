using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class MatchDataPhysics : IMatchData
{
    [DataMember(Name = "user_id")] public string userId;
    [DataMember(Name = "acceleration")] public Vector3 acceleration;
    [DataMember(Name = "velocity")] public Vector3 velocity;
    [DataMember(Name = "position")] public Vector3 position;
}