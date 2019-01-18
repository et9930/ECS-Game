using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MapConfigComponent : IComponent
{
    public MapConfigList list;
}

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
}