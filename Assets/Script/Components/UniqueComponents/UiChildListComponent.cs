using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class UiChildListComponent : IComponent
{
    public Dictionary<int, List<int>> dic;
}