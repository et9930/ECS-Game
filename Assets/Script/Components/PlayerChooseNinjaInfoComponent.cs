using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class PlayerChooseNinjaInfoComponent : IComponent
{
    public string userId;
    public string ninjaName;
}