using System.Runtime.Serialization;

[DataContract]
public class CSGetDataByUserId : ICSMessage
{
    [DataMember(Name = "user_id")] public string userId;
}