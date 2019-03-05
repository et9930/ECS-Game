using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class PhysicsServiceComponent : IComponent
{
    public IPhysicsService instance;
}