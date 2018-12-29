using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class LoadingSceneProcessComponent : IComponent
{
    public float value;
}