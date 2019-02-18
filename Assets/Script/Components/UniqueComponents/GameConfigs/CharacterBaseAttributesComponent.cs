using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CharacterBaseAttributesComponent : IComponent
{
    public Dictionary<string, Attributes> dic;
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

    [DataMember]
    public float baseHealth;
    [DataMember]
    public float baseChaKuRa;
    [DataMember]
    public float chaKuRaSlewRate;
    [DataMember]
    public float baseTaiRyoKu;
    [DataMember]
    public float deathTaiRyoKu;
    [DataMember]
    public float tiredTaiRyoKu;
    

}
