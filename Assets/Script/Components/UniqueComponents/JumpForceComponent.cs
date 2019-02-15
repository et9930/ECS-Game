using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class JumpForceComponent : IComponent
{
    public float value;
}