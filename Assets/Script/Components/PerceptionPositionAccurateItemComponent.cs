using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class PerceptionPositionAccurateItemComponent : IComponent
{
    public string name;
    public bool left;
    public float y;
    public int distance;
}