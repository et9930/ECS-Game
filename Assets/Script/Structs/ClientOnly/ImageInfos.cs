using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;

[DataContract]
public class ImageInfos
{
    [DataMember]
    public Dictionary<string, CharacterInfo> infos;
}

[DataContract]
public class CharacterInfo
{
    [DataMember]
    public string characterName;
    [DataMember]
    public Dictionary<string, AnimationInfo> animationInfos;
}

[DataContract]
public class AnimationInfo
{
    [DataMember]
    public string animationName;
    [DataMember]
    public int maxFrame;
    [DataMember]
    public Dictionary<int, FrameInfo> frameInfos;
}

[DataContract]
public class FrameInfo
{
    [DataMember]
    public string name;
    [DataMember]
    public string path;
    [DataMember]
    public int frameCount;
    [DataMember]
    public Vector2 size;
    [DataMember]
    public Vector2 pivot;
    [DataMember]
    public ForceInfo force;
    [DataMember]
    public List<List<Vector2>> physicsShape;
}

[DataContract]
public class ForceInfo
{
    [DataMember]
    public bool direction;
    [DataMember]
    public Vector3 value;
    [DataMember]
    public float duration;
}