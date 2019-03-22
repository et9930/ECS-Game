using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class CurrentPingTimeComponent : IComponent
{
    public int value;
}