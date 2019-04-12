using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CurrentMatchDataComponent : IComponent
{
    public SCMatchData value;
}