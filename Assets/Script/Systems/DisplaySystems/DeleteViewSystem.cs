using System;
using System.Collections.Generic;
using Entitas;

public class DeleteViewSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public DeleteViewSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DeleteView);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isView && entity.isDeleteView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.viewService.instance.DestroyView(e.name.text);
            e.isDestroy = true;
        }
    }
}