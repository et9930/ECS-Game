using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class LoadPlayerComponent : IComponent
{
    public int playerId;
    public string playerName;
}