using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MouseCurrentPositionComponent : IComponent
{
    public Vector2 value;
}