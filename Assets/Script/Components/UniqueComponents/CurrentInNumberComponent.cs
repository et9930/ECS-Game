using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CurrentInNumberComponent : IComponent
{
    public int value;
}