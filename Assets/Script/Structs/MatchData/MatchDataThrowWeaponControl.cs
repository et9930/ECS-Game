using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class MatchDataThrowWeaponControl : IMatchData
{
    [DataMember(Name = "mid")] public string matchId;
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "wname")] public string weaponName;
    [DataMember(Name = "wid")] public string weaponId;
    [DataMember(Name = "h")] public float hierarchy;
    [DataMember(Name = "left")] public bool left;
    [DataMember(Name = "p")] public Vector3 position;
}