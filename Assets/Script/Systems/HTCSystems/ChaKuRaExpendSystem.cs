using System;
using System.Collections.Generic;
using Entitas;

public class ChaKuRaExpendSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ChaKuRaExpendSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ChaKuRaExpend);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasChaKuRaExpend && entity.hasChaKuRaCurrent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var expendChaKuRa = e.chaKuRaExpend.value;
            if (e.chaKuRaCurrent.value < expendChaKuRa)
            {
                expendChaKuRa = e.chaKuRaCurrent.value;
            }

            e.ReplaceChaKuRaCurrent(e.chaKuRaCurrent.value - expendChaKuRa);
            e.RemoveChaKuRaExpend();
        }
    }
}