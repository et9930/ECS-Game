using System.Runtime.Serialization;

[DataContract]
public class SCPing
{
    [DataMember(Name = "time_stamp")] public double timeStamp;
}