﻿using System.Collections.Generic;
using Entitas;

public class DebugMessageSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public DebugMessageSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        // we only care about entities with DebugMessageComponent 
        return context.CreateCollector(GameMatcher.DebugMessage);
    }

    protected override bool Filter(GameEntity entity)
    {
        // good practice to perform a final check in case 
        // the entity has been altered in a different system.
        return entity.hasDebugMessage && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        // this is the list of entities that meet our conditions
        foreach (var e in entities)
        {
            // we can safely access their DebugMessage component
            // then grab the string data and print it
            _context.logService.instance.LogMessage(e.debugMessage.message);
            e.isDestroy = true;
        }
    }
}