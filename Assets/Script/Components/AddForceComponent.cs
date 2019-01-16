using System.Numerics;
using Entitas;

[Game]
public class AddForceComponent : IComponent
{
    public Vector3 ForceValue;
    public float DurationTime;
}