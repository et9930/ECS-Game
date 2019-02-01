using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class TaiRyoKuComponent : IComponent
{
    public int death;
    public int tired;
    public int current;
    public int total;
}