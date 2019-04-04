using Entitas;

public class RegisterLocalStorageServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ILocalStorageService _localStorageService;

    public RegisterLocalStorageServiceSystem(Contexts contexts, ILocalStorageService localStorageService)
    {
        _context = contexts.game;
        _localStorageService = localStorageService;
    }

    public void Initialize()
    {
        _context.ReplaceLocalStorageService(_localStorageService);
    }
}

