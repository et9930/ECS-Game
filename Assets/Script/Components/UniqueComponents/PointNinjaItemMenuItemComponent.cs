using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class PointNinjaItemMenuItemComponent : IComponent
{
    public string value;
}