using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LastSendPhysicsTimeComponent : IComponent
{
    public double value;
}