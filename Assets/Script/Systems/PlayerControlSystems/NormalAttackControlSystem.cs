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
        if (_context.currentScene.name != "BattleScene") return;
        if (_context.key.value.TaijutsuAttack)
        {
            if (_context.isTaijutsuAttackFreezing) return;
            _context.isTaijutsuAttackFreezing = true;

            var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
            if (currentPlayer == null) return;

            if (!currentPlayer.onTheGround.value || currentPlayer.isJumping || currentPlayer.isMakingYin) return;

            if (!currentPlayer.isNormalAttacking)
            {
                if (currentPlayer.hasCurrentWeapon)
                {
                    currentPlayer.ReplaceAnimation("attack_" + _context.characterBaseAttributes.dic[currentPlayer.name.text].taijutsuAttackWithWeapon, false);
                }
                else
                {
                    currentPlayer.ReplaceAnimation("attack_1", false);
                }
                currentPlayer.ReplaceVelocity(Vector3.Zero);
                currentPlayer.isNormalAttacking = true;
            }
            else
            {
                if (currentPlayer.hasCurrentWeapon) return;

                var currentAttackAnimationName = currentPlayer.animation.name;
                if (!currentAttackAnimationName.StartsWith("attack_")) return;

                var _index = currentAttackAnimationName.LastIndexOf('_');
                var currentAttackIndex = int.Parse(currentAttackAnimationName.Substring(_index + 1));

                if (currentAttackIndex >= _context.characterBaseAttributes.dic[currentPlayer.name.text].taijutsuAttackNum) return;

                currentPlayer.ReplaceNextAnimation("attack_" + (currentAttackIndex + 1), false);
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
