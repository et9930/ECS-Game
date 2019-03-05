using Entitas;

public class RegisterPhysicsServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly IPhysicsService _physicsService;

    public RegisterPhysicsServiceSystem(Contexts contexts, IPhysicsService physicsService)
    {
        _context = contexts.game;
        _physicsService = physicsService;
    }


    public void Initialize()
    {
        _context.ReplacePhysicsService(_physicsService);
    }
}