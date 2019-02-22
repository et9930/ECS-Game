using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MouseInOutEventFuncComponent : IComponent
{
    public Dictionary<string, Action<GameEntity>> inDic;
    public Dictionary<string, Action<GameEntity>> outDic;
}