using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LoadSceneComponent : IComponent
{
    public string name;
}
