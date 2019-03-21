﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class ParentEntityComponent : IComponent
{
    public GameEntity value;
}