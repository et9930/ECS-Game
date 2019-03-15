﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class LeftNumberComponent : IComponent
{
    public int value;
}