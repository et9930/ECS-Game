using System.Numerics;
using Entitas;

[Game]
public class AddForceComponent : IComponent
{
    public Vector2 ForceValue;
    public float DurationTime;
}