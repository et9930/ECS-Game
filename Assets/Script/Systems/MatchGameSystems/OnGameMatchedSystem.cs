using System;
using System.Collections.Generic;
using Entitas;

public class OnGameMatchedSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public OnGameMatchedSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameMatched);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isGameMatched;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            OnGameMatched();
        }
    }

    private async void OnGameMatched()
    {

        var getDataByUserId = new CSGetDataByUserId
        {
            userId = _context.currentPlayerId.value
        };
        var payload = Utilities.ToJson(getDataByUserId);
        var rpcPayload = await _context.networkService.instance.RpcCall("rpc_get_match_data", payload);
        if (rpcPayload == null) return;
        var matchData = Utilities.ParseJson<SCMatchData>(rpcPayload);
        _context.ReplaceCurrentMatchData(matchData);
        
        var result = await _context.networkService.instance.JoinMatch();
        if (!result) return;
        
        _context.sceneService.instance.SetDropdownValue("MatchTypeDropdown", matchData.matchType);

        foreach (var e in _context.GetEntitiesWithName("StartSearchButton"))
        {
            e.ReplaceActive(false);
        }
        foreach (var e in _context.GetEntitiesWithName("StopSearchButton"))
        {
            e.ReplaceActive(false);
        }
        foreach (var e in _context.GetEntitiesWithName("WaitOtherPlayerJoin"))
        {
            e.ReplaceActive(true);
        }
    }

}