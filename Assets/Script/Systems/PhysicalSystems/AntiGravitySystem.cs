using System.Collections.Generic;
using Entitas;

public class AntiGravitySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AntiGravitySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.OnTheGround);
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
            if (e.onTheGround.value)
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y = 0;
                e.ReplaceAcceleration(newAcceleration);

                var newVelocity = e.velocity.value;
                if (newVelocity.Y < 0)
                {
                    newVelocity.Y = 0;
                }
                e.ReplaceVelocity(newVelocity);
            }
            else
            {
                var newAcceleration = e.acceleration.value;
                newAcceleration.Y -= -_context.physicalConstant.gravity;
                e.ReplaceAcceleration(newAcceleration);
            }
        }
    }
}