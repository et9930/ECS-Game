using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class TowardComponent : IComponent
{
    public bool left;
}
