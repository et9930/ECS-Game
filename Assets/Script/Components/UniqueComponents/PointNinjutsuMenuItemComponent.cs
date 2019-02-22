using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class PointNinjutsuMenuItemComponent : IComponent
{
    public string value;
}