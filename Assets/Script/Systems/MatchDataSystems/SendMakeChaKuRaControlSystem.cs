using Entitas;

public class SendMakeChaKuRaControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public SendMakeChaKuRaControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.hasBattleOver) return;

        if (_context.currentScene.name != "BattleScene") return;
        if (_context.isReplaying) return;
        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null) return;

        if (!_context.key.value.MakeChaKuRa)
        {
            if (!currentPlayer.isMakingChaKuRa) return;
            var newMakeChaKuRaControl = new MatchDataMakeChaKuRaControl
            {
                matchId = _context.currentMatchData.value.customMatchId,
                userId = _context.currentPlayerId.value,
                isMakingChaKuRa = false
            };
            _context.CreateEntity().ReplaceSendMatchData(1006, Utilities.ToJson(newMakeChaKuRaControl));
        }
        else
        {
            if (!currentPlayer.hasChaKuRaCurrent || !currentPlayer.hasChaKuRaTotal || !currentPlayer.hasChaKuRaSlewRate ||
                !currentPlayer.hasTaiRyoKuCurrent || !currentPlayer.hasTaiRyoKuDeath) return;

            if (!(currentPlayer.chaKuRaCurrent.value < currentPlayer.chaKuRaTotal.value) ||
                !(currentPlayer.taiRyoKuCurrent.value > currentPlayer.taiRyoKuDeath.value))
            {
                if (!currentPlayer.isMakingChaKuRa) return;
                var newMakeChaKuRaControl = new MatchDataMakeChaKuRaControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = _context.currentPlayerId.value,
                    isMakingChaKuRa = false
                };
                _context.CreateEntity().ReplaceSendMatchData(1006, Utilities.ToJson(newMakeChaKuRaControl));
            }
            else
            {
                if (currentPlayer.isMakingChaKuRa) return;
                var newMakeChaKuRaControl = new MatchDataMakeChaKuRaControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = _context.currentPlayerId.value,
                    isMakingChaKuRa = true
                };
                _context.CreateEntity().ReplaceSendMatchData(1006, Utilities.ToJson(newMakeChaKuRaControl));
            }
        }
    }
}