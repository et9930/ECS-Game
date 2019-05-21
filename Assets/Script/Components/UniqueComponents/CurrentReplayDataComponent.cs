using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CurrentReplayDataComponent : IComponent
{
    public SCMatchRecord value;
}