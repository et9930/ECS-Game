using System.Collections.Generic;
using System.Runtime.Serialization;

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