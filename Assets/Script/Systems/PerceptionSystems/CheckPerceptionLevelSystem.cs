using System.Numerics;
using Entitas;

public class CheckPerceptionLevelSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public CheckPerceptionLevelSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (_context.GetGroup(GameMatcher.LoadPlayer).count > 0) return;

        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        var perceptionLevel = currentPlayer.perceptionLevel.value;

        foreach (var e in _context.GetEntitiesWithTag("Character"))
        {
            if (e == currentPlayer) continue;

            var antiPerceptionLevel = e.antiPerceptionLevel.value;
            var distance = Vector3.Distance(currentPlayer.position.value, e.position.value);
            var finalLevel = perceptionLevel - antiPerceptionLevel - (int)distance / 15;

            e.ReplaceFinalPerceptionLevel(finalLevel);
        }
    }
}