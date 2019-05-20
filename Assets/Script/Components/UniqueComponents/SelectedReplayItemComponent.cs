using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SelectedReplayItemComponent : IComponent
{
    public GameEntity entity;
}