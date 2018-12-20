using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ViewServiceComponent : IComponent
{
    public IViewService instance;
}