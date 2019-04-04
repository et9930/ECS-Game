using System.Runtime.Serialization;

[DataContract]
public class SCUserData
{
    [DataMember(Name = "username")]      public string username;
    [DataMember(Name = "head_shot")]     public string headShot;
    [DataMember(Name = "user_level")]    public int userLevel;
    [DataMember(Name = "user_exp")]      public int userExp;
    [DataMember(Name = "battle_number")] public int battleNumber;
    [DataMember(Name = "win_rate")]      public float winRate;
    [DataMember(Name = "ninja_number")]  public int ninjaNumber;
    [DataMember(Name = "level_s")]       public int levelS;
    [DataMember(Name = "level_a")]       public int levelA;
    [DataMember(Name = "level_b")]       public int levelB;
    [DataMember(Name = "level_c")]       public int levelC;
    [DataMember(Name = "level_d")]       public int levelD;
}