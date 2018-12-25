using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LoadConfigServiceComponent : IComponent
{
    public ILoadConfigService instance;
}