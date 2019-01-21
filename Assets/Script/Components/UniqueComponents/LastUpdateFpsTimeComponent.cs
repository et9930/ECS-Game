using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LastUpdateFpsTimeComponent : IComponent
{
    public float value;
}