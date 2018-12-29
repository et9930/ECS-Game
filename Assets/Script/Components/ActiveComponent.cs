using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class ActiveComponent : IComponent
{
    public bool value;
}