using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class CollisionPairList
{
    [DataMember]
    public List<CollisionPair> list;
}

[DataContract]
public class CollisionPair
{
    [DataMember]
    public string first;
    [DataMember]
    public string second;
}