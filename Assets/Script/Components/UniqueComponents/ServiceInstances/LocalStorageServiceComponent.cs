using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LocalStorageServiceComponent : IComponent
{
    public ILocalStorageService instance;
}