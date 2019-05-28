using System.Collections.Generic;
using System.Numerics;
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
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            var healthReduceValue = e.healthReduce.value;
            if (healthReduceValue > e.healthCurrent.value)
            {
                healthReduceValue = e.healthCurrent.value;
                e.ReplaceAcceleration(Vector3.Zero);
                e.ReplaceVelocity(Vector3.Zero);
                e.isDead = true;
            }

            e.ReplaceHealthCurrent(e.healthCurrent.value - healthReduceValue);
            e.RemoveHealthReduce();
        }
    }
}