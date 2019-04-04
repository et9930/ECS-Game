using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CollisionPairConfigComponent : IComponent
{
    public List<CollisionPair> list;
}