using System.Collections.Generic;
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
            foreach (var e in _context.GetGroup(GameMatcher.PlayerId))
            {
                if (e.playerId.value == _context.currentPlayerId.value)
                {
                    if (!e.isBusying)
                    {
                        e.ReplaceAnimation("attack_1", false);
                        e.isBusying = true;
                    }
                }
            }
        }
    }
}
