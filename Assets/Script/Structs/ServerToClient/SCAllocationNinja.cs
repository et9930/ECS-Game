using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class SCAllocationNinja
{
    [DataMember(Name = "custom_match_id")] public string customMatchId;
    [DataMember(Name = "ninja_list")] public List<AllocationNinjaItem> ninjaList;
    [DataMember(Name = "map")] public AllocationMap map;
    [DataMember(Name = "match_type")] public int matchType;
}

[DataContract]
public class AllocationNinjaItem
{
    [DataMember(Name = "ninja_id")] public int ninjaId;
    [DataMember(Name = "ninja_name")] public string ninjaName;
}

[DataContract]
public class AllocationMap
{
    [DataMember(Name = "map_id")] public int mapId;
    [DataMember(Name = "map_name")] public string mapName;
}