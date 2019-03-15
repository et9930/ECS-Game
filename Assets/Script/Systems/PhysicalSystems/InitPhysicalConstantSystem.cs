using Entitas;

public class InitPhysicalConstantSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitPhysicalConstantSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplacePhysicalConstant(
            -5f, // Gravity
            10.0f   // Friction Coefficient
        );
    }
}

