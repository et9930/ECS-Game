using System;
using System.Collections.Generic;
using Entitas;

public class ErrorMessageSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ErrorMessageSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ErrorMessage);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasErrorMessage && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.logService.instance.ErrorMessage(e.errorMessage.message);
            e.isDestroy = true;
        }
    }
}
