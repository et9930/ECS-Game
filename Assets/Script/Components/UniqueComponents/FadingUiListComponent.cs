using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class FadingUiListComponent : IComponent
{
    public List<string> list;
}