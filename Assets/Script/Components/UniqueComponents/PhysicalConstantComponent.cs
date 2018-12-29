using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class PhysicalConstantComponent : IComponent
{
    public float gravity;
    public float frictionCoefficient;
}