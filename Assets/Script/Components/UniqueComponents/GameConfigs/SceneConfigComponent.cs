using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SceneConfigComponent : IComponent
{
    public Dictionary<string, Scene> dic;
}

[DataContract]
public class SceneConfigs
{
    [DataMember]
    public Dictionary<string, Scene> Scenes;
}

[DataContract]
public class Scene
{
    [DataMember]
    public string SceneName;
    [DataMember]
    public List<string> Uis;
}

