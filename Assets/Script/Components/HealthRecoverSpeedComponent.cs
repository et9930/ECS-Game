using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class HealthRecoverSpeedComponent : IComponent
{
    public float value;
}