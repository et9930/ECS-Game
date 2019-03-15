using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ThrowWeaponNumberComponent : IComponent
{
    public int value;
}