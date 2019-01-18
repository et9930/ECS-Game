using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CurrentMapNameComponent : IComponent
{
    public string value;
}