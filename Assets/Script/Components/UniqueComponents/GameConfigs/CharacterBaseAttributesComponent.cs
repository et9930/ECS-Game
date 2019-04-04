using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CharacterBaseAttributesComponent : IComponent
{
    public Dictionary<string, Character> dic;
}