using Entitas;

public class RegisterTimeServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ITimeService _timeService;

    public RegisterTimeServiceSystem(Contexts contexts, Services services)
    {
        _context = contexts.game;
        _timeService = services.Time;
    }

    public void Initialize()
    {
        _context.ReplaceTimeService(_timeService);
    }
}