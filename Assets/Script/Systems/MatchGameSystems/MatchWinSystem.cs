using System.Collections.Generic;
using Entitas;

public class MatchWinSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public MatchWinSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.WinControl);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasWinControl && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.ReplaceBattleOver(e.winControl.value.winTeam);
            var ui = _context.CreateEntity();
            ui.ReplaceName("BattleSceneOver");
            ui.ReplaceUiOpen("BattleSceneOver");
        }
    }
}