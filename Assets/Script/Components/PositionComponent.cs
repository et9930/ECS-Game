using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self), Event(EventTarget.Any)]
public class PositionComponent : IComponent
{
    public Vector3 value;
}
