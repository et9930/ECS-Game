using System;
using System.Collections.Generic;
using Entitas;

public class InitMainSceneSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public InitMainSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CurrentScene);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCurrentScene && entity.currentScene.name == "MainScene";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            GetUserData();
        }
    }

    private async void GetUserData()
    {
        var getUserData = new CSGetDataByUserId()
        {
            userId = _context.currentPlayerId.value
        };
        var payload = Utilities.ToJson(getUserData);
        var rpcPayload = await _context.networkService.instance.RpcCall("rpc_get_user_data", payload);
        if (rpcPayload == null) return;
        var userData = Utilities.ParseJson<SCUserData>(rpcPayload);
        _context.ReplaceCurrentPlayerUserData(userData);
    }
}