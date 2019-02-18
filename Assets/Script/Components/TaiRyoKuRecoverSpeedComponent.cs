using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class TaiRyoKuRecoverSpeedComponent : IComponent
{
    public float value;
}