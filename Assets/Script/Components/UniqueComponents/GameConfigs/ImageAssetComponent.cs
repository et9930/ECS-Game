using Entitas;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ImageAssetComponent : IComponent
{
    public ImageInfos imageInfos;
}

[DataContract]
public class ImageInfos
{
    [DataMember]
    public List<CharacterInfo> infos;
}

[DataContract]
public class CharacterInfo
{
    [DataMember]
    public string characterName;
    [DataMember]
    public List<AnimationInfo> animationInfos;
}

[DataContract]
public class AnimationInfo
{
    [DataMember]
    public string animationName;
    [DataMember]
    public List<FrameInfo> frameInfos;
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
}