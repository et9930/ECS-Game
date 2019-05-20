using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class SCMatchRecord
{
    [DataMember(Name = "match_record")] public List<SingleRecord> matchRecord;
}

[DataContract]
public class SingleRecord
{
    [DataMember(Name = "time")] public int time;
    [DataMember(Name = "op_code")] public long opCode;
    [DataMember(Name = "data")] public string data;
}