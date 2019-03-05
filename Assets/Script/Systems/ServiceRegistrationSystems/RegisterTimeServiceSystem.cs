using Entitas;

public class RegisterTimeServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ITimeService _timeService;

    public RegisterTimeServiceSystem(Contexts contexts, ITimeService timeService)
    {
        _context = contexts.game;
        _timeService = timeService;
    }

    public void Initialize()
    {
        _context.ReplaceTimeService(_timeService);
    }
}