﻿using System;
using System.Collections.Generic;
using Entitas;

public class OpenUiSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public OpenUiSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceUuidToEntity(new Dictionary<int, GameEntity>());
        var e = _context.CreateEntity();
        e.isUiOpen = true;
        e.ReplaceName("GameState");

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
            GameEntity rootEntity = null;
            var id = _context.sceneService.instance.OpenUI(e.name.text, _context.uiConfig.UiInfos[e.name.text].UiLayer, _context, ref rootEntity);
            _context.uuidToEntity.dic[id] = rootEntity;
            e.AddUiRootId(id);
            e.isUiOpen = false;
        }
    }


}