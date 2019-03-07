using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class IdComponent : IComponent
{
    [EntityIndex]
    public int value;
}