using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MakeYinTimeComponent : IComponent
{
    public float value;
}