using System;
using System.Collections.Generic;
using Entitas;

public class CheckJoinNumberSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CheckJoinNumberSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }


    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllPlayerJoined);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAllPlayerJoined;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (!_context.hasCurrentMatchData) return;

        foreach (var e in entities)
        {
            foreach (var ui in _context.GetEntitiesWithName("ReadyWindow"))
            {
                ui.ReplaceActive(true);
            }

            foreach (var ui in _context.GetEntitiesWithName("WaitOtherPlayerJoin"))
            {
                ui.ReplaceActive(false);
            }

            for (var i = 1; i <= _context.currentMatchData.value.matchSize; i++)
            {
                foreach (var ui in _context.GetEntitiesWithName("Player" + i))
                {
                    ui.ReplaceActive(true);
                }
            }
        }
    }


}