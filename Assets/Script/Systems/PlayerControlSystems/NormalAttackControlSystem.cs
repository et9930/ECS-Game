using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class NormalAttackControlSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public NormalAttackControlSystem(Contexts contexts):base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NormalAttackControl);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasNormalAttackControl && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            var player = _context.GetEntityWithId(e.normalAttackControl.value.userId);
            if (player == null) continue;
            if (e.normalAttackControl.value.immediately)
            {
                player.ReplaceAnimation("attack_" + e.normalAttackControl.value.attackIndex, false);
                player.ReplaceVelocity(Vector3.Zero);
                player.isNormalAttacking = true;
            }
            else
            {
                player.ReplaceNextAnimation("attack_" + e.normalAttackControl.value.attackIndex, false);
            }
        }
    }
}
