using System.Runtime.Serialization;

[DataContract]
public class SCChooseNinja
{
    [DataMember(Name = "user_id")] public string userId;
    [DataMember(Name = "confirm")] public bool confirm;
    [DataMember(Name = "ninja_name")] public string ninjaName;
}