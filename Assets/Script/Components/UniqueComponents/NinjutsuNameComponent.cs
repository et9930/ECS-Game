﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class NinjutsuNameComponent : IComponent
{
    public string value;
}