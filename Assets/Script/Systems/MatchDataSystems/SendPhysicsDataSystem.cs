using System.Collections.Generic;
using Entitas;

public class SendPhysicsDataSystem : IExecuteSystem, IInitializeSystem
{
    private readonly GameContext _context;

    public SendPhysicsDataSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceLastSendPhysicsTime(0.0f);
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;

        var currentTime = Utilities.GetTimeStamp();
        if (currentTime - _context.lastSendPhysicsTime.value <= 5000.0f) return;

        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null || currentPlayer.isInitializePhysical) return;

        var newPhysicsData = new MatchDataPhysics
        {
            userId = _context.currentPlayerId.value,
            acceleration = currentPlayer.acceleration.value,
            position = currentPlayer.position.value,
            velocity = currentPlayer.velocity.value
        };

        _context.CreateEntity().ReplaceSendMatchData(1002, Utilities.ToJson(newPhysicsData));
        _context.ReplaceLastSendPhysicsTime(currentTime);
    }
}