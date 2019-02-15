using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class MouseCurrentPositionComponent : IComponent
{
    public Vector2 value;
}