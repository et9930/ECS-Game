using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class LoadPlayerComponent : IComponent
{
    public string playerId;
    public string playerName;
    public Vector3 position;
    public bool towardLeft;
    public int team;
}