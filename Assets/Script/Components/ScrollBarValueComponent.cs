﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class ScrollBarValueComponent : IComponent
{
    public float value;
}