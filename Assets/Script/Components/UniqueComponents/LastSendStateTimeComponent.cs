using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LastSendStateTimeComponent : IComponent
{
    public double value;
}