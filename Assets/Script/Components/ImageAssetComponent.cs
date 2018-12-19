using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ImageAssetComponent : IComponent
{
    public Infos infos;
}

public class Infos : ScriptableObject
{
    public List<CharacterInfo> infos;
}

[System.Serializable]
public class CharacterInfo
{
    public string characterName;
    public List<AnimationInfo> animationInfos;
}

[System.Serializable]
public class AnimationInfo
{
    public string animationName;
    public List<FrameInfo> frameInfos;
}

[System.Serializable]
public class FrameInfo
{
    public string name;
    public string path;
    public int frameCount;
    public Vector2 size;
    public Vector2 pivot;
}