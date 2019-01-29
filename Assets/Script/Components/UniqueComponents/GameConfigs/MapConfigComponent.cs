using System.Collections.Generic;
using System.Numerics;
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

    [DataMember]
    public Vector3 Camera_1_Position;
    [DataMember]
    public Vector3 Camera_2_Position;

    [DataMember]
    public Vector3 Character_1_InPosition;
    [DataMember]
    public Vector3 Character_2_InPosition;
    [DataMember]
    public Vector3 Character_3_InPosition;
    [DataMember]
    public Vector3 Character_4_InPosition;
    [DataMember]
    public Vector3 Character_5_InPosition;
    [DataMember]
    public Vector3 Character_6_InPosition;
    [DataMember]
    public Vector3 Character_7_InPosition;
    [DataMember]
    public Vector3 Character_8_InPosition;

}