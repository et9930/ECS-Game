using System.Runtime.Serialization;

[DataContract]
public class SCGetUuid
{
    [DataMember(Name = "uuid")] public string uuid;
}