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
        if (_context.key.value.TaijutsuAttack)
        {
            foreach (var e in _context.GetGroup(GameMatcher.Id))
            {
                if (e.id.value == _context.currentPlayerId.value)
                {
                    if (e.isShadow)
                        continue;

                    if (!e.isBusying && e.isOnTheGround)
                    {
                        e.ReplaceVelocity(Vector3.Zero);
                        e.ReplaceAnimation("skill_3", false);
                        e.isBusying = true;
                    }
                }
            }
        }
    }
}