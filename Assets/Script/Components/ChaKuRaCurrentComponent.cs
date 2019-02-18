using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class ChaKuRaCurrentComponent : IComponent
{
    public float value;
}