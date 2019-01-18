using Entitas;

public class GameInitializeSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public GameInitializeSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceCurrentScene("LaunchScene");
        _context.ReplaceLoadScene("BattleScene");

    }
}

