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
        foreach (var e in _context.GetGroup(GameMatcher.Id))
        {
            if (e.isShadow)
                continue;

            if (e.position.value.Y > 0)
            {
                _context.CreateEntity().ReplaceDebugMessage(e.name.text + " leave ground");
                e.isOnTheGround = false;
            }

            if (e.position.value.Y <= 0)
            {
                e.isOnTheGround = true;
            }
        }
    }
}

