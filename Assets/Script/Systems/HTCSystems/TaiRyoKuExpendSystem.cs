using System.Collections.Generic;
using Entitas;

public class TaiRyoKuExpendSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public TaiRyoKuExpendSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TaiRyoKuExpend);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTaiRyoKuExpend && entity.hasTaiRyoKuCurrent && entity.hasTaiRyoKuDeath;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            var expendTaiRyoKu = e.taiRyoKuExpend.value;
            if (e.taiRyoKuCurrent.value - e.taiRyoKuDeath.value < expendTaiRyoKu)
            {
                expendTaiRyoKu = e.taiRyoKuCurrent.value - e.taiRyoKuDeath.value;
            }

            e.ReplaceTaiRyoKuCurrent(e.taiRyoKuCurrent.value - expendTaiRyoKu);
            e.RemoveTaiRyoKuExpend();
        }
    }
}