using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class ScaleComponent : IComponent
{
    public Vector2 value;
}