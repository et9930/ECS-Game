using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ReplayStartTimeComponent : IComponent
{
    public double value;
}