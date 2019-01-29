using Entitas;

public class AntiGravitySystem : IExecuteSystem
{
    private readonly GameContext _context;

    public AntiGravitySystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;

        foreach (var e in _context.GetGroup(GameMatcher.AllOf(GameMatcher.AffectedByGravity, GameMatcher.Acceleration)))
        {
            if (e.isOnTheGround || e.isOnTheWall)
            { 
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y = 0;
                e.ReplaceAcceleration(newAcceleration);

                if(e.isOnTheGround)
                {
                    var newVelocity = e.velocity.value;
                    newVelocity.Y = 0;
                    e.ReplaceVelocity(newVelocity);
                }
            }
            else
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y -= -_context.physicalConstant.gravity;
                e.ReplaceAcceleration(newAcceleration);
            }
        }
    }
}