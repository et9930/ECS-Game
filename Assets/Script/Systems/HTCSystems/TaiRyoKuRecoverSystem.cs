using Entitas;

public class TaiRyoKuRecoverSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public TaiRyoKuRecoverSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.hasBattleOver) return;

        foreach (var e in _context.GetGroup(GameMatcher.TaiRyoKuCurrent))
        {
            if (e.isDead) continue;
            if (!e.hasAnimation || e.animation.name != "idle") continue;
            if (e.taiRyoKuCurrent.value >= e.taiRyoKuTotal.value) continue;
            if (e.taiRyoKuCurrent.value < e.taiRyoKuTired.value) continue;

            var newTaiRyoKu = e.taiRyoKuCurrent.value + e.taiRyoKuRecoverSpeed.value * _context.timeService.instance.GetDeltaTime();
            if (newTaiRyoKu > e.taiRyoKuTotal.value)
            {
                newTaiRyoKu = e.taiRyoKuTotal.value;
            }
            e.ReplaceTaiRyoKuCurrent(newTaiRyoKu);
        }
    }
}