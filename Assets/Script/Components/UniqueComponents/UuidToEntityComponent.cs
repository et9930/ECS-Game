using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class UuidToEntityComponent : IComponent
{
    public Dictionary<int, GameEntity> dic = new Dictionary<int, GameEntity>();
}

