using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class UiConfigComponent : IComponent
{
    public Dictionary<string, UiInfo> UiInfos;
}

