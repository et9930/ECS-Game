using Entitas;

public class PlayerStateControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public PlayerStateControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        foreach (var e in _context.GetGroup(GameMatcher.Id))
        {
            if (e.isShadow)
                continue;

            if (e.position.value.Y > 0)
            {
                e.ReplaceOnTheGround(false);

//                _context.CreateEntity().ReplaceDebugMessage(_context.timeService.instance.GetRealTimeSinceStartup() + "");
            }

            if (e.position.value.Y <= 0)
            {
                e.ReplaceOnTheGround(true);
//                _context.CreateEntity().ReplaceDebugMessage(_context.timeService.instance.GetRealTimeSinceStartup() + "");

            }
        }
    }
}

