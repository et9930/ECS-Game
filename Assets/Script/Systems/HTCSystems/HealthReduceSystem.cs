using System;
using System.Collections.Generic;
using Entitas;

public class HealthReduceSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    
    public HealthReduceSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.HealthReduce);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealthReduce && entity.hasHealthCurrent && entity.hasHealthTotal;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var healthReduceValue = e.healthReduce.value;
            if (healthReduceValue > e.healthCurrent.value)
            {
                healthReduceValue = e.healthCurrent.value;
            }

            e.ReplaceHealthCurrent(e.healthCurrent.value - healthReduceValue);
            e.RemoveHealthReduce();
        }
    }
}