using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class NameComponent : IComponent
{
    [EntityIndex]
    public string text;
}