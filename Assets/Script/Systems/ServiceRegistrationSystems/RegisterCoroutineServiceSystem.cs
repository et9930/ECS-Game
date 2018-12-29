using Entitas;

public class RegisterCoroutineServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ICoroutineService _coroutineService;

    public RegisterCoroutineServiceSystem(Contexts contexts, ICoroutineService coroutineService)
    {
        _context = contexts.game;
        _coroutineService = coroutineService;
    }

    public void Initialize()
    {
        _context.ReplaceCoroutineService(_coroutineService);
    }
}