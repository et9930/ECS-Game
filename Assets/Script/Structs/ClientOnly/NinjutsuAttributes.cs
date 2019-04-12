using System.Collections.Generic;
using System.Runtime.Serialization;

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