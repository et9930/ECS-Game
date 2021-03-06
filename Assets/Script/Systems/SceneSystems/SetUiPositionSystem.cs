﻿using System.Collections.Generic;
using Entitas;

public class SetUiPositionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public SetUiPositionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SetUiPosition);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSetUiPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.sceneService.instance.SetUILocalPosition(e.setUiPosition.uiName, e.setUiPosition.position);
            e.isDestroy = true;
        }
    }
}