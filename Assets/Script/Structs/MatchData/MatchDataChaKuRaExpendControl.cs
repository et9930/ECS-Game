﻿using System.Runtime.Serialization;

[DataContract]
public class MatchDataChaKuRaExpendControl : IMatchData
{
    [DataMember(Name = "uid")] public string userId;
    [DataMember(Name = "cexpend")] public float chaKuRaExpend;
}