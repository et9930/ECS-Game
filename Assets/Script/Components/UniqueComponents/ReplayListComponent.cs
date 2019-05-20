using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ReplayListComponent : IComponent
{
    public SCReplayList value;
}