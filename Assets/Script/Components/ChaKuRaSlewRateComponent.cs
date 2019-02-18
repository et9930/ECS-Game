using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class ChaKuRaSlewRateComponent : IComponent
{
    public float value;
}