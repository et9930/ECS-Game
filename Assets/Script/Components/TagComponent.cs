using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class TagComponent : IComponent
{
    [EntityIndex]
    public string value;
}