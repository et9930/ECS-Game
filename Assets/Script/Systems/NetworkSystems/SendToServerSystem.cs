using System;
using System.Collections.Generic;
using Entitas;

public class SendToServerSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public SendToServerSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SendToServer);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSendToServer && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            
        }
    }
}