using System;
using System.Collections.Generic;
using Entitas;

public class JutsuControlSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public JutsuControlSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JutsuControl);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasJutsuControl && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            var jutsu = _context.CreateEntity();
            jutsu.isJutsu = true;
            jutsu.ReplaceName(e.jutsuControl.value.jutsuName);
            var originator = _context.GetEntityWithId(e.jutsuControl.value.originatorId);
            if(originator == null) continue;
            jutsu.ReplaceOriginator(originator);
            if (e.jutsuControl.value.needTarget)
            {
                var target = _context.GetEntityWithId(e.jutsuControl.value.targetId);
                if (target == null) continue;
                jutsu.ReplaceJutsuTarget(target);
            }
            jutsu.isStartConditionConfirm = true;
            e.isDestroy = true;
        }
    }
}