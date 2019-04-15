using System.Runtime.Serialization;

[DataContract]
public class SCReadyState
{
    [DataMember(Name = "custom_match_id")] public string customMatchId;
    [DataMember(Name = "ready_state")] public bool readyState;
    [DataMember(Name = "ready_number")] public int readyNumber;
}