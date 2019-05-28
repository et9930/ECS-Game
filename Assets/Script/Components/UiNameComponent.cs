using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class UiNameComponent : IComponent
{
    [EntityIndex]
    public string value;
}