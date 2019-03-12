using System;
using System.Collections.Generic;
using Entitas;

public class ShadowPositionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;  

    public ShadowPositionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasId && !entity.isShadow;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var shadow in _context.GetGroup(GameMatcher.Shadow))
            {
                if (shadow.parentEntity.value != e) continue;

                var shadowPosition = e.position.value;
                shadowPosition.Y = 0;
                shadow.ReplacePosition(shadowPosition);

                var shadowHierarchy = e.hierarchy.value;
                shadowHierarchy += 0.01f;
                shadow.ReplaceHierarchy(shadowHierarchy);
            }
        }
    }
}