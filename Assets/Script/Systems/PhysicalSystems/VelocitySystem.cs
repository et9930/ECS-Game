using Entitas;

public class VelocitySystem : IExecuteSystem
{
    private readonly GameContext _context;

    public VelocitySystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.Velocity))
        {
            if (e.isMoving)
            {
                var newPosition = e.position.value;
                newPosition.X += e.velocity.value.X * Utilities.GetFixedDeltaTime();
                newPosition.Y += e.velocity.value.Y * Utilities.GetFixedDeltaTime();
                e.ReplacePosition(newPosition);
            }
        }
    }
}