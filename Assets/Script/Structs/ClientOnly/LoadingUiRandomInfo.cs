using System.Collections.Generic;
using System.Runtime.Serialization;

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