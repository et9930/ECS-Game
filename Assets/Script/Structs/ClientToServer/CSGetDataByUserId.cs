using System.Runtime.Serialization;

[DataContract]
public class CSGetDataByUserId
{
    [DataMember(Name = "user_id")] public string userId;
}