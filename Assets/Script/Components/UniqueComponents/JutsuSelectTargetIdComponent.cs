using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class JutsuSelectTargetIdComponent : IComponent
{
    public int value;
}