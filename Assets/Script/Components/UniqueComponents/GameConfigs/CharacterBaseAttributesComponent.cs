using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CharacterBaseAttributesComponent : IComponent
{
    public CharacterBaseAttributes list;
}

[DataContract]
public class CharacterBaseAttributes
{
    [DataMember]
    public Dictionary<string, Attributes> list;
}

[DataContract]
public class Attributes
{
    [DataMember]
    public float baseVelocity;
}
