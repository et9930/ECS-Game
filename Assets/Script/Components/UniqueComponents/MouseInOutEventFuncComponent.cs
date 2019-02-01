using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MouseInOutEventFuncComponent : IComponent
{
    public Dictionary<string, Action> inDic;
    public Dictionary<string, Action> outDic;
}