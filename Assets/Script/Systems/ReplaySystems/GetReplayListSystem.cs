using System;
using System.Collections.Generic;
using Entitas;

public class GetReplayListSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public GetReplayListSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.RequestReplayList);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isRequestReplayList;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isRequestReplayList = false;
            RequestReplayList();
            
        }
    }

    private async void RequestReplayList()
    {
        var getDataByUserId = new CSGetDataByUserId
        {
            userId = _context.currentPlayerId.value
        };

        var result = await _context.networkService.instance.RpcCall("rpc_get_replay_list", Utilities.ToJson(getDataByUserId));
        if (result != null)
        {
            _context.ReplaceReplayList(Utilities.ParseJson<SCReplayList>(result));
        }
    }
}