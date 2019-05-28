﻿using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class JumpControlSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public JumpControlSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JumpControl);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasJumpControl && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            var player = _context.GetEntityWithId(e.jumpControl.value.userId);
            if (player == null) continue;

            switch (e.jumpControl.value.state)
            {
                case 0:
                    player.ReplaceVelocity(Vector3.Zero);
                    player.ReplaceAnimation("jump_0", false);
                    break;
                case 1:
                    player.ReplaceAnimation("jump_1", false);
                    break;
                case 2:
                    player.ReplaceAddForce(e.jumpControl.value.force, 0.04f);
                    _context.CreateEntity().ReplaceDebugMessage(e.jumpControl.value.force.ToString());
                    player.ReplaceAnimation("jump_1", false);
                    player.isJumping = false;
                    break;
            }
        }
    }
}