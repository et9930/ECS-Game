using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entitas;

public class SendMatchDataSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public SendMatchDataSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SendMatchData);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSendMatchData && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            SendMatchData(e.sendMatchData.dataCode, e.sendMatchData.payload);
            e.isDestroy = true;
        }
    }

    private async void SendMatchData(long dataCode, string payload)
    {
        var result = await _context.networkService.instance.SendMatchData(dataCode, payload);
        if (result)
        {
            _context.CreateEntity().ReplaceMatchData(dataCode, payload);
        }
    }
}