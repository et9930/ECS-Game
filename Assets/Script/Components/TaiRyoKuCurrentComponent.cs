using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class TaiRyoKuCurrentComponent : IComponent
{
    public float value;
}