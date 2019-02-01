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
    public int baseHealth;
    [DataMember]
    public int baseChaKuRa;
    [DataMember]
    public int baseTaiRyoKu;
    [DataMember]
    public int deathTaiRyoKu;
    [DataMember]
    public int tiredTaiRyoKu;
    

}
