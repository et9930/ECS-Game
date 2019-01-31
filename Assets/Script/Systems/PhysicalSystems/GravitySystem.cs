using System.Collections.Generic;
using Entitas;

public class GravitySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public GravitySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.AffectedByGravity, GameMatcher.Acceleration));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAffectedByGravity && entity.hasAcceleration;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.currentScene.name != "BattleScene") return;

        foreach (var e in entities)
        {
            if (e.isAffectedByGravity)
            {
                if (e.isGravity) continue;

                var newAcceleration = e.acceleration.value;
                newAcceleration.Y += _context.physicalConstant.gravity;
                e.ReplaceAcceleration(newAcceleration);
                e.isGravity = true;
            }
            else
            {
                if (!e.isGravity) continue;

                var newAcceleration = e.acceleration.value;
                newAcceleration.Y -= _context.physicalConstant.gravity;
                e.ReplaceAcceleration(newAcceleration);
                e.isGravity = false;
            }
        }
    }
}