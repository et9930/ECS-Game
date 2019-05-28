using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class BattleOverComponent : IComponent
{
    public int winTeam;
}
