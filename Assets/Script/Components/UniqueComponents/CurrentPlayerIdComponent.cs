﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class CurrentPlayerIdComponent : IComponent
{
    public string value;
}