using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LastGetPingTimeComponent : IComponent
{
    public float value;
}