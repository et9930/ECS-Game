using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class HealthCurrentComponent : IComponent
{
    public float value;
}
