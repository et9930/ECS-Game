using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class PerceptionPositionAccurateComponent : IComponent
{
    public Dictionary<string, GameEntity> dic;
}