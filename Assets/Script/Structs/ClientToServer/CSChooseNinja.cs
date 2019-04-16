using System.Runtime.Serialization;

[DataContract]
public class CSChooseNinja
{
    [DataMember(Name = "ninja_name")] public string ninjaName;
    [DataMember(Name = "confirm")] public bool confirm;
}