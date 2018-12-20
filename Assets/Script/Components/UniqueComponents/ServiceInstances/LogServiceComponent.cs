using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LogServiceComponent : IComponent
{
    public ILogService instance;
}