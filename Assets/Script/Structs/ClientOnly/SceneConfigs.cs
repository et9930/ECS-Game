using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
public class SceneConfigs
{
    [DataMember] public Dictionary<string, Scene> Scenes;
}

[DataContract]
public class Scene
{
    [DataMember] public string SceneName;
    [DataMember] public List<string> InitializeUis;
    [DataMember] public List<string> CloseUIs;
}

