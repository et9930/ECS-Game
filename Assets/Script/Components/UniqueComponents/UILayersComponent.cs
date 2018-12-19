using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class UiLayersComponent : IComponent
{
    public Dictionary<string, GameObject> uiLayers;
}
