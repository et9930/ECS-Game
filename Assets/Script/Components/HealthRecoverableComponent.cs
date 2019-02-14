using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class HealthRecoverableComponent : IComponent
{
    public float value;
}