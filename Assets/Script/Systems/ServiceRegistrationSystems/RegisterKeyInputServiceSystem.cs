using Entitas;

public class RegisterKeyInputServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly IKeyInputService _keyInputService;

    public RegisterKeyInputServiceSystem(Contexts contexts, IKeyInputService keyInputService)
    {
        _context = contexts.game;
        _keyInputService = keyInputService;
    }

    public void Initialize()
    {
        _context.ReplaceKeyInputService(_keyInputService);
    }
}