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
            -9.81f, // Gravity
            10.0f   // Friction Coefficient
        );
    }
}

