using Entitas;

public class PlayerTryThrowWeaponSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public PlayerTryThrowWeaponSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);

        if (_context.key.value.ThrowWeapon)
        {
            if(_context.isTryThrowWeaponFreezing) return;

            if (currentPlayer.isNormalAttacking || currentPlayer.isJumping || currentPlayer.isMakingYin || currentPlayer.isMakingChaKuRa) return;

            currentPlayer.isTryThrowWeapon = true;
            _context.isTryThrowWeaponFreezing = true;
        }
        else
        {
            if (_context.isTryThrowWeaponFreezing)
            {
                _context.isTryThrowWeaponFreezing = false;
            }
        }
    }
}