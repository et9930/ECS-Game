using System.Numerics;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class BattleValueDisplayComponent : IComponent
{
    public int value;
    public int valueType;
    public Vector3 textColor;
    public string text;
    public GameEntity parent;
}