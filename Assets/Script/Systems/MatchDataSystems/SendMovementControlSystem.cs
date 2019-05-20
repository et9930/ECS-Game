using Entitas;

public class SendMovementControlSystem : IExecuteSystem, IInitializeSystem
{
    private readonly GameContext _context;

    public SendMovementControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceLastMovementKeyState(0.0f, 0.0f);
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;

        if (_context.key.value.Horizontal != 0.0f && _context.key.value.Horizontal != 1.0f && _context.key.value.Horizontal != -1.0f || 
            _context.key.value.Vertical != 0.0f && _context.key.value.Vertical != 1.0f && _context.key.value.Vertical != -1.0f) return;

        if (_context.key.value.Horizontal == _context.lastMovementKeyState.horizontal &&
            _context.key.value.Vertical == _context.lastMovementKeyState.vertical) return;

        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null || currentPlayer.isInitializePhysical) return;

        if (!currentPlayer.onTheGround.value || currentPlayer.isNormalAttacking || currentPlayer.isJumping) return;

        var newMovementControl = new MatchDataMovementControl()
        {
            matchId = _context.currentMatchData.value.customMatchId,
            userId = _context.currentPlayerId.value,
            horizontal = _context.key.value.Horizontal,
            vertical = _context.key.value.Vertical
        };

        _context.CreateEntity().ReplaceSendMatchData(1001, Utilities.ToJson(newMovementControl));
        _context.ReplaceLastMovementKeyState(_context.key.value.Horizontal, _context.key.value.Vertical);
    }
}