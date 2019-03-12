using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class PerceptionPositionExistItemComponent : IComponent
{
    public string name;
    public int distance;
    public bool left;
}