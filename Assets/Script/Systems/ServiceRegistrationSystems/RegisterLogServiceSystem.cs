using Entitas;

public class RegisterLogServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ILogService _logService;

    public RegisterLogServiceSystem(Contexts contexts, ILogService logService)
    {
        _context = contexts.game;
        _logService = logService;
    }

    public void Initialize()
    {
        _context.ReplaceLogService(_logService);
    }
}