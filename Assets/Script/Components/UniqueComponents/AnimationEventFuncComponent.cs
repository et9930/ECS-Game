using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class AnimationEventFuncComponent : IComponent
{
    public Dictionary<string, CharacterEvent> characterDic;
}

public class CharacterEvent
{
    public Dictionary<string, AnimationEvent> animationDic;
}

public class AnimationEvent
{
    public Dictionary<int, Action<GameEntity>> frameDic;
}