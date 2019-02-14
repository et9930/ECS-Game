
using Entitas;

public class HealthRecoverSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public HealthRecoverSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.HealthCurrent))
        {
            if (e.healthCurrent.value >= e.healthRecoverable.value) continue;

            var newHealth = e.healthCurrent.value + e.healthRecoverSpeed.value * _context.timeService.instance.GetDeltaTime();
            if (newHealth > e.healthRecoverable.value)
            {
                newHealth = e.healthRecoverable.value;
            }
            e.ReplaceHealthCurrent(newHealth);
        }
    }
}