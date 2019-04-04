using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class UiLayerConfigComponent : IComponent
{
    public UiLayerInfos config;
}

