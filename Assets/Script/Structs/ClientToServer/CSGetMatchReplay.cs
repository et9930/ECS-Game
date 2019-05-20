using System.Runtime.Serialization;

[DataContract]
public class CSGetMatchReplay
{
    [DataMember(Name = "match_id")] public string matchId;
}