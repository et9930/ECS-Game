using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class QuickActionList
{
    [DataMember]
    public List<QuickAction> list;
}

[DataContract]
public class QuickAction
{
    [DataMember]
    public string name;
    [DataMember]
    public bool allNinja;
    [DataMember]
    public List<string> requireNinja;
    [DataMember]
    public List<string> requireFlag;
    [DataMember]
    public List<string> requireNoFlag;
    [DataMember]
    public string describe;
}