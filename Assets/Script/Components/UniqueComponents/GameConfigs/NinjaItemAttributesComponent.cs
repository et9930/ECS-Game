using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class NinjaItemAttributesComponent : IComponent
{
    public Dictionary<string, NinjaItem> dic;
}

[DataContract]
public class NinjaItemAttributes
{
    [DataMember]
    public Dictionary<string, NinjaItem> dic;
}

[DataContract]
public class NinjaItem
{
    [DataMember]
    public string ninjaItemName;
    [DataMember]
    public string ninjaItemDescribe;
    [DataMember]
    public string ninjaItemEffect;
}