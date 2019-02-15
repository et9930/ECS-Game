using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class JumpAngleComponent : IComponent
{
    public float value;
}