using Entitas;

public class RegisterNetworkServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly INetworkService _networkService;

    public RegisterNetworkServiceSystem(Contexts contexts, INetworkService networkService)
    {
        _context = contexts.game;
        _networkService = networkService;
    }

    public void Initialize()
    {
        _context.ReplaceNetworkService(_networkService);
    }
}