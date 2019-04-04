using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SceneConfigComponent : IComponent
{
    public Dictionary<string, Scene> dic;
}