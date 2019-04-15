using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class AllocationNinjaComponent : IComponent
{
    public SCAllocationNinja value;
}