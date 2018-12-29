using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CoroutineServiceComponent : IComponent
{
    public ICoroutineService instance;
}