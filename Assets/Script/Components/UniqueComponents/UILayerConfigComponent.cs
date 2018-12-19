using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class UiLayerConfigComponent : IComponent
{
    public UiLayers config;
}

[System.Serializable]
public class UiLayers
{
    public List<UiLayerInfo> UILayers;
}

[System.Serializable]
public class UiLayerInfo
{
    public string Name;
    public int PlaneDistance;
    public int OrderInLayer;
}