using Entitas;

public class CleanupDebugMessageSystem : ICleanupSystem
{
    readonly LogContext _context;
    readonly IGroup<LogEntity> _debugMessages;

    public CleanupDebugMessageSystem(Contexts contexts)
    {
        _context = contexts.log;
        _debugMessages = _context.GetGroup(LogMatcher.DebugMessage);
    }

    public void Cleanup()
    {
        // group.GetEntities() always gives us an up to date list
        foreach (var e in _debugMessages.GetEntities())
        {
            e.Destroy();
        }
    }
}