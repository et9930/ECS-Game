using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class MovementControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public MovementControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }
    
    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.PlayerId))
        {
            if (e.playerId.value == _context.currentPlayerId.value)
            {
                if (e.isOnTheGround)
                {
                    if (_context.key.value.Horizontal != 0.0f || _context.key.value.Vertical != 0.0f)
                    {
                        e.isMoving = true;
                    }
                    else
                    {
                        e.isMoving = false;
                    }

                    var tmpHorizontal = _context.key.value.Horizontal * _context.characterBaseAttributes.list.list[e.name.text].baseVelocity;
                    var tmpVertical = _context.key.value.Vertical * _context.characterBaseAttributes.list.list[e.name.text].baseVelocity;
                    e.ReplaceVelocity(new Vector3(tmpHorizontal, 0, tmpVertical));

                    if (_context.key.value.Horizontal > 0)
                    {
                        e.ReplaceToward(false);
                    }
                    else if (_context.key.value.Horizontal < 0)
                    {
                        e.ReplaceToward(true);
                    }
                }
            }
        }
    }
}