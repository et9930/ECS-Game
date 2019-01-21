using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class AnimationFrameRateComponent : IComponent
{
    public int value;
}