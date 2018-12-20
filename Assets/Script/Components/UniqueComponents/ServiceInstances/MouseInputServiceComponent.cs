using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MouseInputServiceComponent : IComponent
{
    public IMouseInputService instance;
}