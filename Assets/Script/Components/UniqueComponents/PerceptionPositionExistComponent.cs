using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class PerceptionPositionExistComponent : IComponent
{
    public Dictionary<string, GameEntity> dic;
}
