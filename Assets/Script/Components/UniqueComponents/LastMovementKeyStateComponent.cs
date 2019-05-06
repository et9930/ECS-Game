using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LastMovementKeyStateComponent : IComponent
{
    public float horizontal;
    public float vertical;
}