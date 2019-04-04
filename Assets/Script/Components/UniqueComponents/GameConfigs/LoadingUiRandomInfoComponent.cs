using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LoadingUiRandomInfoComponent : IComponent
{
    public List<RandomText> RandomTexts;
    public List<RandomImage> RandomImages;
}