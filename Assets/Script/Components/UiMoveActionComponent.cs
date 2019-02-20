using System.Numerics;
using Entitas;

[Game]
public class UiMoveActionComponent : IComponent
{
    public string uiName;
    public bool moveFor;
    public Vector2 moveLocation;
    public float moveDuration;
}