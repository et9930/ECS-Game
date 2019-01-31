using System;
using System.Collections.Generic;
using Entitas;

public class CloseUiSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CloseUiSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiClose);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isUiClose && entity.hasUiRootId;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var uiEntity in _context.GetEntities(GameMatcher.UiRootId))
            {
                if (uiEntity.uiRootId.value == e.uiRootId.value)
                {
                    uiEntity.isDestroy = true;
                }
            }
            _context.sceneService.instance.CloseUI(e.uiRootId.value);
            _context.uuidToEntity.dic.Remove(e.uiRootId.value);
        }
    }
}