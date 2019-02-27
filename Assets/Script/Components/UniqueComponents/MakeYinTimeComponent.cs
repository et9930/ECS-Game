using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class MakeYinTimeComponent : IComponent
{
    public float value;
}