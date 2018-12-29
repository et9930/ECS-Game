using Entitas;

public class GravitySystem : IExecuteSystem
{
    private readonly GameContext _context;

    public GravitySystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.AffectedByGravity))
        {
            if (e.isAffectedByGravity)
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y += _context.physicalConstant.gravity;
                e.ReplaceAcceleration(newAcceleration);
            }
            else
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y -= _context.physicalConstant.gravity;
                e.ReplaceAcceleration(newAcceleration);
            }
        }
    }
}