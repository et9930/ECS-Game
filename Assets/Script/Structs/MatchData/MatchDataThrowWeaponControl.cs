using System.Runtime.Serialization;

[DataContract]
public class MatchDataThrowWeaponControl : IMatchData
{
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "throw")] public bool isThrowWeapon;
}