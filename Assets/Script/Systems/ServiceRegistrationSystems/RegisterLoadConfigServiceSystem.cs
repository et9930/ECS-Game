using Entitas;

public class RegisterLoadConfigServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ILoadConfigService _loadConfigService;

    public RegisterLoadConfigServiceSystem(Contexts contexts, ILoadConfigService loadConfigService)
    {
        _context = contexts.game;
        _loadConfigService = loadConfigService;
    }

    public void Initialize()
    {
        _context.ReplaceLoadConfigService(_loadConfigService);
    }
}