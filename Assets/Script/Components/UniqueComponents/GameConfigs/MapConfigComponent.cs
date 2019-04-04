using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MapConfigComponent : IComponent
{
    public Dictionary<string, MapConfig> list;
}