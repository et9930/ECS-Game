using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class JumpAngleComponent : IComponent
{
    public float Vertical;
    public float Horizontal;
}