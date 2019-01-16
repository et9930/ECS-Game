using System;
using Entitas;

public class AccelerationSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public AccelerationSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.Acceleration))
        {
            if (e.acceleration.value.Length() > 0.0f)
            {
                var newSpeed = e.velocity.value;
                newSpeed.X += e.acceleration.value.X * _context.timeService.instance.GetFixedDeltaTime();
                newSpeed.Y += e.acceleration.value.Y * _context.timeService.instance.GetFixedDeltaTime();
                e.isMoving = newSpeed.Length() > 0.0f;
                e.ReplaceVelocity(newSpeed);
            }
        }
    }
}
