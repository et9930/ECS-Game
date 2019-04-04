using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class ChangeUiParentSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    
    public ChangeUiParentSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ParentEntity);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasParentEntity && !entity.hasUiOpen && entity.hasUiRootId;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var kvPair in _context.uiChildList.dic)
            {
                if (kvPair.Value.Contains(e.uiRootId.value))
                {
                    kvPair.Value.Remove(e.uiRootId.value);
                }
            }

            if (e.parentEntity.value.hasUiRootId)
            {
                _context.sceneService.instance.SetParent(e.uiRootId.value, e.parentEntity.value.name.text);
                _context.sceneService.instance.SetUILocalPosition(e.name.text,
                    e.hasUiExcursion ? e.uiExcursion.value : Vector2.Zero);
                _context.uiChildList.dic[e.parentEntity.value.uiRootId.value].Add(e.uiRootId.value);
            }
            else
            {
                _context.sceneService.instance.SetParent(e.uiRootId.value, "NormalLayer");
            }

        }
    }
}