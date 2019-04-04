using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class CurrentPlayerUserDataComponent : IComponent
{
    public SCUserData value;
}