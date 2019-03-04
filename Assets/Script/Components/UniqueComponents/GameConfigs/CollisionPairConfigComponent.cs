using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CollisionPairConfigComponent : IComponent
{
    public List<CollisionPair> list;
}

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