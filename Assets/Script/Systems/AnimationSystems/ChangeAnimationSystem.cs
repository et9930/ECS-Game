﻿using System.Collections.Generic;
using Entitas;

public class ChangeAnimationSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ChangeAnimationSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Animation);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAnimation;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasCurrentAnimation)
            {
                if (e.currentAnimation.name == e.animation.name)
                {
                    continue;
                }
            }
            _context.CreateEntity().ReplaceDebugMessage("Change " + e.name.text + " animation to " + e.animation.name);
            if (e.animation.name == "idle")
            {
                e.isNormalAttacking = false;
//                e.isMoving = false;
            }
            e.ReplaceCurrentAnimation(e.animation.name);
            e.ReplaceAnimationFrame(0);
        }
    }
}