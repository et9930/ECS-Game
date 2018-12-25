using Entitas;

public class RegisterUiServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ISceneService _sceneService;

    public RegisterUiServiceSystem(Contexts contexts, ISceneService sceneService)
    {
        _context = contexts.game;
        _sceneService = sceneService;
    }

    public void Initialize()
    {
        _context.ReplaceSceneService(_sceneService);
    }
}