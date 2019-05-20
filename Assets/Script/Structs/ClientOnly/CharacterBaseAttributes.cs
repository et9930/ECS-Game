using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class CharacterBaseAttributes
{
    [DataMember]
    public Dictionary<string, Character> list;
}

[DataContract]
public class Character
{
    [DataMember]
    public string name;
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

    [DataMember]
    public int taijutsuAttackNum;
    [DataMember]
    public int taijutsuAttackWithWeapon;
    [DataMember]
    public float taijutsuAttackRange;

    [DataMember]
    public List<string> ninjutsuList;
    [DataMember]
    public Dictionary<string, int> ninjaItemList;

    [DataMember]
    public int ninjutsu;
    [DataMember]
    public int taijutsu;
    [DataMember]
    public int genjutsu;
    [DataMember]
    public int yin;
    [DataMember]
    public int power;
    [DataMember]
    public int speed;
    [DataMember]
    public int chakura;
    [DataMember]
    public int intelligence;

    [DataMember]
    public int perceptionLevel;
    [DataMember]
    public int antiPerceptionLevel;
}
