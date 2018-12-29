using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LoadingUiRandomInfoComponent : IComponent
{
    public List<RandomText> RandomTexts;
    public List<RandomImage> RandomImages;
}

[DataContract]
public class LoadingUiRandomInfo
{
    [DataMember]
    public List<RandomText> RandomTexts;
    [DataMember]
    public List<RandomImage> RandomImages;
}

[DataContract]
public class RandomText
{
    [DataMember]
    public string Title;
    [DataMember]
    public string Text;
}

[DataContract]
public class RandomImage
{
    [DataMember]
    public string Path;
}