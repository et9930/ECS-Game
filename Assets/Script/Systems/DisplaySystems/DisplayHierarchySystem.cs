using System.Collections.Generic;
using Entitas;

public class DisplayHierarchySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public DisplayHierarchySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasHierarchy && !entity.isShadow;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if(!_context.hasCurrentMapName) return;

        var hierarchyConfig = _context.mapConfig.list.list[_context.currentMapName.value].CharacterDisplayHierarchy;
        foreach (var e in entities)
        {
            var lastHierarchy = 1.0f;

            foreach (var config in hierarchyConfig)
            {
                if (e.position.value.Z < config.Z)
                {
                    lastHierarchy = config.Hierarchy;
                }
            }

            e.ReplaceHierarchy(lastHierarchy);
        }
        
    }
}
