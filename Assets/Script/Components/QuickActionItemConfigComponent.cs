using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class QuickActionItemConfigComponent : IComponent
{
    public QuickAction value;
}