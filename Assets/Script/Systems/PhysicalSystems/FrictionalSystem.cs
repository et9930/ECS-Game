using System;
using Entitas;

public class FrictionalSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public FrictionalSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;

        foreach (var e in _context.GetGroup(GameMatcher.AllOf(GameMatcher.OnTheGround, GameMatcher.Acceleration, GameMatcher.Velocity)))
        {
            if(e.velocity.value.X == 0.0f && e.velocity.value.Z == 0.0f) continue;
            //if(e.isMoving) continue;
            if (_context.key.value.Horizontal != 0.0f || _context.key.value.Vertical != 0.0f) continue;
            if (!e.onTheGround.value) continue;
            
            var totalVelocity = (float)Math.Sqrt(Math.Pow(e.velocity.value.X, 2) + Math.Pow(e.velocity.value.Z, 2));
            var totalSlidingFriction = _context.physicalConstant.frictionCoefficient;
            var slidingFrictionX = totalSlidingFriction * e.velocity.value.X / totalVelocity;
            var slidingFrictionZ = totalSlidingFriction * e.velocity.value.Z / totalVelocity;

            var newVelocity = e.velocity.value;
            newVelocity.X -= slidingFrictionX;
            newVelocity.Z -= slidingFrictionZ;

            if (newVelocity.X * e.velocity.value.X < 0)
                newVelocity.X = 0;
            
            if (newVelocity.Z * e.velocity.value.Z < 0)
                newVelocity.Z = 0;
            
            e.ReplaceVelocity(newVelocity);
        }

        foreach (var e in _context.GetGroup(GameMatcher.OnTheWall))
        {
            if (e.velocity.value.Y > 0.0f)
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y -= _context.physicalConstant.frictionCoefficient;
                e.ReplaceAcceleration(newAcceleration);
            }
            else if (e.velocity.value.Y < 0.0f)
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y += _context.physicalConstant.frictionCoefficient;
                e.ReplaceAcceleration(newAcceleration);
            }
        }
    }
}