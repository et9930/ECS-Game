using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ButtonClickEventFuncComponent : IComponent
{
    public Dictionary<string, Action> buttonClickDic;
}