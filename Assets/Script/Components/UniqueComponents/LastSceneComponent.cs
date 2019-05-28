using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LastSceneComponent : IComponent
{
    public string value;
}