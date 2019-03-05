﻿using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class NormalAttackControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public NormalAttackControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (!_context.key.value.TaijutsuAttack) return;

        foreach (var e in _context.GetGroup(GameMatcher.Id))
        {
            if (e.id.value != _context.currentPlayerId.value) continue;
            if (e.isShadow) continue;
            if (e.isNormalAttacking || !e.onTheGround.value || e.isJumping || e.isMakingYin) continue;

            e.ReplaceVelocity(Vector3.Zero);
            e.ReplaceAnimation("skill_3", false);
            e.isNormalAttacking = true;
        }
    }
}