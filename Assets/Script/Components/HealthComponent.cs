using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class HealthComponent : IComponent
{
    public int total;
    public int current;
    public int recoverable;
}
