﻿using System;
using System.Collections.Generic;
using Entitas;

public class OpenUiSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public OpenUiSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiOpen);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isUiOpen && entity.hasName;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.AddUiRootId(_context.sceneService.instance.OpenUI(e.name.text, "NormalLayer", _context));
            e.isUiOpen = false;
        }
    }
    
}