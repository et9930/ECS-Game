using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class SelectTargetDistanceComponent : IComponent
{
    public int value;
}