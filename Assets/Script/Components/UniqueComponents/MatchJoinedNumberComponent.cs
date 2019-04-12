using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MatchJoinedNumberComponent : IComponent
{
    public int value;
}