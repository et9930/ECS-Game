using Entitas;

public class RegisterViewServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly IViewService _viewService;

    public RegisterViewServiceSystem(Contexts contexts, IViewService viewService)
    {
        _context = contexts.game;
        _viewService = viewService;
    }

    public void Initialize()
    {
        _context.ReplaceViewService(_viewService);
    }
}