using System.Runtime.Serialization;

[DataContract]
public class GetDataByUserId : ICSMessage
{
    [DataMember(Name = "user_id")] public string userId;
}