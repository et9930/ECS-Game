using System;
using System.Collections.Generic;
using Entitas;

public class PlayerReadyStateSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public PlayerReadyStateSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MatchReadyState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMatchReadyState;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.matchReadyState.value.readyState)
            {
                for (var i = 1; i <= e.matchReadyState.value.readyNumber; i++)
                {
                    foreach (var ui in _context.GetEntitiesWithName("Player" + i +"Ready"))
                    {
                        ui.ReplaceActive(true);
                    }
                }

                for (var i = e.matchReadyState.value.readyNumber + 1; i <= 8; i++)
                {
                    foreach (var ui in _context.GetEntitiesWithName("Player" + i + "Ready"))
                    {
                        ui.ReplaceActive(false);
                    }
                }
            }
            else
            {
                LeaveMatch();
            }
            e.isDestroy = true;
        }
    }

    private async void LeaveMatch()
    {
        var readyMatch = new CSReadyMatch
        {
            ready = false
        };
        var strReadyMatch = Utilities.ToJson(readyMatch);
        var rpcPayload = await _context.networkService.instance.RpcCall("rpc_ready_match", strReadyMatch);
        if (rpcPayload == null) return;

        foreach (var e in _context.GetEntitiesWithName("SearchBattleWindow"))
        {
            e.isUiClose = true;
        }

        _context.isGameMatched = false;
        _context.isSearchingBattle = false;
        _context.isAllPlayerJoined = false;
        _context.RemoveCurrentMatchData();
    }
}