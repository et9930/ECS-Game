﻿using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class RotationComponent : IComponent
{
    public Vector3 value;
}