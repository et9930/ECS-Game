using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class TimeServiceComponent : IComponent
{
    public ITimeService instance;
}