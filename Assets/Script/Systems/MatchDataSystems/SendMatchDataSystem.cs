using System;
using System.Collections.Generic;
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
            _context.networkService.instance.SendMatchData(e.sendMatchData.dataCode, e.sendMatchData.payload);
            e.isDestroy = true;
        }
    }
}