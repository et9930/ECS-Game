using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class CurrentWeaponComponent : IComponent
{
    public string value;
}