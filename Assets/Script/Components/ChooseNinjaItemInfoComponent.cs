using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class ChooseNinjaItemInfoComponent : IComponent
{
    public AllocationNinjaItem value;
}