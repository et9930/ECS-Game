using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class CurrentFpsComponent : IComponent
{
    public float value;
}