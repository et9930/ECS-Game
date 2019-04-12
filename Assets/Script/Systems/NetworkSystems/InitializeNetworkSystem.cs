using Entitas;

public class InitializeNetworkSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitializeNetworkSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.networkService.instance.InitializeNetworkService("127.0.0.1", 8000);
    }

}