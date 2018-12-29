using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SceneConfigComponent : IComponent
{
    public SceneConfigs SceneConfig;
}

[DataContract]
public class SceneConfigs
{
    [DataMember]
    public List<Scene> Scenes;
}

[DataContract]
public class Scene
{
    [DataMember]
    public string SceneName;
    [DataMember]
    public List<string> Uis;
}

