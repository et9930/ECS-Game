using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class SelectTargetComponent : IComponent
{
    public GameEntity value;
}