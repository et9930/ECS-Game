﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class NinjaItemNameComponent : IComponent
{
    public string value;
}