using System.Runtime.Serialization;

[DataContract]
public class GetUserData : ICSMessage
{
    [DataMember(Name = "user_id")] public string userId;
}