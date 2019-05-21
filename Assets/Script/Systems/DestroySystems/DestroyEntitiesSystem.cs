using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DestroyEntitiesSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public DestroyEntitiesSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.isView)
            {
                _context.viewService.instance.DestroyView(e.name.text);
            }
            e.Destroy();
        }
    }
}
