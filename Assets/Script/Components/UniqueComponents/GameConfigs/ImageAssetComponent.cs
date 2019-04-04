using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ImageAssetComponent : IComponent
{
    public Dictionary<string, CharacterInfo> infos;
}