using Entitas;

public class RegisterMouseInputServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly IMouseInputService _mouseInputService;

    public RegisterMouseInputServiceSystem(Contexts contexts, IMouseInputService mouseInputService)
    {
        _context = contexts.game;
        _mouseInputService = mouseInputService;
    }

    public void Initialize()
    {
        _context.ReplaceMouseInputService(_mouseInputService);
    }
}