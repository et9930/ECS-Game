using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class QuickActionExecuteFuncComponent : IComponent
{
    public Dictionary<string, Action<GameEntity>> dic;
}