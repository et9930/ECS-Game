using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class NinjaItemAttributesComponent : IComponent
{
    public Dictionary<string, NinjaItem> dic;
}