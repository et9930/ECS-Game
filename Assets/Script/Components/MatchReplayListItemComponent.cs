using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class MatchReplayListItemComponent : IComponent
{
    public int index;
    public SCMatchData matchData;
}