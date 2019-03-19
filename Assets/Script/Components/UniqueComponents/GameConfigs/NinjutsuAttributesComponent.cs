using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class NinjutsuAttributesComponent : IComponent
{
    public Dictionary<string, Ninjutsu> dic;
}

[DataContract]
public class NinjutsuAttributes
{
    [DataMember] public Dictionary<string, Ninjutsu> dic;
}

[DataContract]
public class Ninjutsu
{
    [DataMember] public string ninjutsuName;
    [DataMember] public float chaKuRaCoast;
    [DataMember] public float taiRyuKuCoast;
    [DataMember] public bool needSelectTarget;
    [DataMember] public List<string> targetFlag;
    [DataMember] public List<string> targetNoFlag;
    [DataMember] public bool isContinuous;
    [DataMember] public NinjutsuClass ninjutsuClass;
    [DataMember] public List<NinjutsuNature> ninjutsuNatures;
    [DataMember] public List<NinjutsuType> ninjutsuTypes;
    [DataMember] public List<NinjutsuRange> ninjutsuRanges;
    [DataMember] public List<NinjutsuEffect> ninjutsuEffects;
    [DataMember] public string ninjutsuDescribe;
    [DataMember] public List<Yin> ninjutsuFullYin;
    [DataMember] public List<Yin> ninjutsuLevelOneYin;
    [DataMember] public List<Yin> ninjutsuLevelTwoYin;
    [DataMember] public List<Yin> ninjutsuLevelThreeYin;
}

public enum NinjutsuClass
{
    S = 1,
    A,
    B,
    C,
    D,
    E
}

public enum NinjutsuNature
{
    Fire = 1,
    Wind,
    Thunder,
    Soil,
    Water,
    Yin,
    Yang
}

public enum NinjutsuType
{
    Nin = 1,
    Tai,
    Gen
}

public enum NinjutsuRange
{
    Close = 1,
    Middle,
    Far
}

public enum NinjutsuEffect
{
    Attack = 1,
    Defense,
    Assist
}

public enum Yin
{
    Zi = 1,
    Yin,
    Chen,
    Wu,
    Shen,
    Xu
}