using Entitas;

public class CalculateFpsSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;

    public CalculateFpsSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceCurrentFps(0);
        _context.ReplaceLastUpdateFpsTime(0);
    }

    public void Execute()
    {
        var currentTime = _context.timeService.instance.GetRealTimeSinceStartup();
        //        _context.ReplaceCurrentFps(1/(currentTime - _context.lastUpdateFpsTime.value));
        _context.ReplaceCurrentFps(1 / (_context.timeService.instance.GetDeltaTime()));
        _context.ReplaceLastUpdateFpsTime(currentTime);
    }
}