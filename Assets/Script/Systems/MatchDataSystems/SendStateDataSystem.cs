using System.Collections.Generic;
using Entitas;

public class SendStateDataSystem : IExecuteSystem, IInitializeSystem
{
    private readonly GameContext _context;

    public SendStateDataSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceLastSendStateTime(0.0f);
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;

        var currentTime = _context.timeService.instance.GetTimeStamp();
        if (currentTime - _context.lastSendStateTime.value <= 5000.0f) return;

        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null || currentPlayer.isInitializePhysical) return;

        var newStateData = new MatchDataState
        {
            userId = _context.currentPlayerId.value,
            acceleration = currentPlayer.acceleration.value,
            position = currentPlayer.position.value,
            velocity = currentPlayer.velocity.value,
            currentChaKuRa = currentPlayer.chaKuRaCurrent.value,
            currentTaiRyoKu = currentPlayer.taiRyoKuCurrent.value,
            currentHealth = currentPlayer.healthCurrent.value
        };

        _context.CreateEntity().ReplaceSendMatchData(1002, Utilities.ToJson(newStateData));
        _context.ReplaceLastSendStateTime(currentTime);
    }
}