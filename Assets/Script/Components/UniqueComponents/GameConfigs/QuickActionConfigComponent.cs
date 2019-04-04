using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class QuickActionConfigComponent : IComponent
{
    public List<QuickAction> list;
}