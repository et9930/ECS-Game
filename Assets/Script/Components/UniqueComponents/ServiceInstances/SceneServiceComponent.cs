using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SceneServiceComponent : IComponent
{
    public ISceneService instance;
}