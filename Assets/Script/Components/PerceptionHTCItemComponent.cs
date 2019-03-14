using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class PerceptionHTCItemComponent : IComponent
{
    public float healthPercent;
    public float taiRyoKuPercent;
    public float chaKuRaPercent;
}