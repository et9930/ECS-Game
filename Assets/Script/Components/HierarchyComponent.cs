using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class HierarchyComponent : IComponent
{
    public float value;
}