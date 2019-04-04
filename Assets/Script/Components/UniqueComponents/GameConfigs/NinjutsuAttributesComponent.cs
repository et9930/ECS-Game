﻿using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class NinjutsuAttributesComponent : IComponent
{
    public Dictionary<string, Ninjutsu> dic;
}