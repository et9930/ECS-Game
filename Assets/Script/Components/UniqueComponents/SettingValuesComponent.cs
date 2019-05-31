using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class SettingValuesComponent : IComponent
{
    public List<Resolution> resolutions;
    public Resolution currentResolution;
    public bool isFullScreen;
}