using System.Collections.Generic;
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
            if (_context.isTaijutsuAttackFreezing) return;
            _context.isTaijutsuAttackFreezing = true;

            foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
            {
                if (e.isShadow) continue;
                if (!e.onTheGround.value || e.isJumping || e.isMakingYin) continue;

                if (!e.isNormalAttacking)
                {
                    if (e.hasCurrentWeapon)
                    {
                        e.ReplaceAnimation("attack_" + _context.characterBaseAttributes.dic[e.name.text].taijutsuAttackWithWeapon, false);
                    }
                    else
                    {
                        e.ReplaceAnimation("attack_1", false);
                    }
                    e.ReplaceVelocity(Vector3.Zero);
                    e.isNormalAttacking = true;
                }
                else
                {
                    if (e.hasCurrentWeapon) return;

                    var currentAttackAnimationName = e.animation.name;
                    if (!currentAttackAnimationName.StartsWith("attack_")) return;

                    var _index = currentAttackAnimationName.LastIndexOf('_');
                    var currentAttackIndex = int.Parse(currentAttackAnimationName.Substring(_index + 1));

                    if (currentAttackIndex >= _context.characterBaseAttributes.dic[e.name.text].taijutsuAttackNum) return;

                    e.ReplaceNextAnimation("attack_" + (currentAttackIndex + 1), false);
                }

            }
        }
        else
        {
            if (_context.isTaijutsuAttackFreezing)
            {
                _context.isTaijutsuAttackFreezing = false;
            }
        }
        
    }
}
