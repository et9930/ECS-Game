using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class MapConfigList
{
    [DataMember]
    public Dictionary<string, MapConfig> list;
}

[DataContract]
public class MapConfig
{
    [DataMember]
    public float CameraMinX;
    [DataMember]
    public float CameraMaxX;

    [DataMember]
    public float CharacterMinX;
    [DataMember]
    public float CharacterMaxX;
    [DataMember]
    public float CharacterMinZ;
    [DataMember]
    public float CharacterMaxZ;

    [DataMember]
    public List<Vector3> CameraPosition;

    [DataMember]
    public List<Vector3> CharacterInPosition;

    [DataMember]
    public List<DisplayHierarchy> CharacterDisplayHierarchy;
}

[DataContract]
public class DisplayHierarchy
{
    [DataMember]
    public float Z;
    [DataMember]
    public float Hierarchy;
}