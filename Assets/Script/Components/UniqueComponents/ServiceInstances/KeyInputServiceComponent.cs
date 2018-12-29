using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class KeyInputServiceComponent : IComponent
{
    public IKeyInputService instance;
}