using System.Numerics;
using Entitas;

public class SendNormalAttackControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public SendNormalAttackControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.hasBattleOver) return;

        if (_context.currentScene.name != "BattleScene") return;
        if (_context.isReplaying) return;
        if (_context.key.value.TaijutsuAttack)
        {
            if (_context.isTaijutsuAttackFreezing) return;
            _context.isTaijutsuAttackFreezing = true;

            var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
            if (currentPlayer == null) return;
            if (currentPlayer.isDead) return;
            if (!currentPlayer.onTheGround.value || currentPlayer.isJumping || currentPlayer.isMakingYin) return;

            if (!currentPlayer.isNormalAttacking)
            {
                if (currentPlayer.hasCurrentWeapon)
                {
//                    currentPlayer.ReplaceAnimation("attack_" + _context.characterBaseAttributes.dic[currentPlayer.name.text].taijutsuAttackWithWeapon, false);
                    var newNormalAttack = new MatchDataNormalAttackControl
                    {
                        matchId = _context.currentMatchData.value.customMatchId,
                        userId = _context.currentPlayerId.value,
                        attackIndex = _context.characterBaseAttributes.dic[currentPlayer.name.text]
                            .taijutsuAttackWithWeapon,
                        immediately = true
                    };
                    _context.CreateEntity().ReplaceSendMatchData(1004, Utilities.ToJson(newNormalAttack));
                }
                else
                {
                    var newNormalAttack = new MatchDataNormalAttackControl
                    {
                        matchId = _context.currentMatchData.value.customMatchId,
                        userId = _context.currentPlayerId.value,
                        attackIndex = 1,
                        immediately = true
                    };
                    _context.CreateEntity().ReplaceSendMatchData(1004, Utilities.ToJson(newNormalAttack));
                }
            }
            else
            {
                if (currentPlayer.hasCurrentWeapon) return;

                var currentAttackAnimationName = currentPlayer.animation.name;
                if (!currentAttackAnimationName.StartsWith("attack_")) return;

                var _index = currentAttackAnimationName.LastIndexOf('_');
                var currentAttackIndex = int.Parse(currentAttackAnimationName.Substring(_index + 1));

                if (currentAttackIndex >= _context.characterBaseAttributes.dic[currentPlayer.name.text].taijutsuAttackNum) return;

                var newNormalAttack = new MatchDataNormalAttackControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = _context.currentPlayerId.value,
                    attackIndex = currentAttackIndex + 1,
                    immediately = false
                };
                _context.CreateEntity().ReplaceSendMatchData(1004, Utilities.ToJson(newNormalAttack));
                //                currentPlayer.ReplaceNextAnimation("attack_" + (currentAttackIndex + 1), false);
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