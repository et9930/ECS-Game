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
        foreach (var e in _context.GetGroup(GameMatcher.OnTheGround))
        {
            if (e.velocity.value.X > 0.0f)
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.X -= _context.physicalConstant.frictionCoefficient;
                e.ReplaceAcceleration(newAcceleration);
            }
            else if(e.velocity.value.X < 0.0f)
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.X += _context.physicalConstant.frictionCoefficient;
                e.ReplaceAcceleration(newAcceleration);
            }
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