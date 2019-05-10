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
        _context.networkService.instance.InitializeNetworkService(_context.serverConfig.value.ip, _context.serverConfig.value.port);
    }

}