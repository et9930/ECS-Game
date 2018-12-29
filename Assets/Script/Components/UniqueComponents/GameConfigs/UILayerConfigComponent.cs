using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class UiLayerConfigComponent : IComponent
{
    public UiLayerInfos config;
}

[DataContract]
public class UiLayerInfos
{
    [DataMember]
    public List<UiLayerInfo> UILayers;
}

[DataContract]
public class UiLayerInfo
{
    [DataMember]
    public string Name;
    [DataMember]
    public int PlaneDistance;
    [DataMember]
    public int OrderInLayer;
}