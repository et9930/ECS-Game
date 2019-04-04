using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class UiInfoList
{
    [DataMember]
    public List<UiInfo> UIConfigs;
}

[DataContract]
public class UiInfo
{
    [DataMember]
    public string UiName;
    [DataMember]
    public string UiLayer;
    [DataMember]
    public List<ComponentInfo> Components;
}

[DataContract]
public class ComponentInfo
{
    [DataMember]
    public string ComponentName;
    [DataMember]
    public string ComponentPath;
    [DataMember]
    public bool AnomalyButton;
    [DataMember]
    public List<string> Listener;
    [DataMember]
    public List<string> Handle;
    [DataMember]
    public bool saveEntity;
}
