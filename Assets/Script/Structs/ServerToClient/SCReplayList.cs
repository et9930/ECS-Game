using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class SCReplayList
{
    [DataMember(Name = "replay_list")] public List<SCMatchData> replayList;
}