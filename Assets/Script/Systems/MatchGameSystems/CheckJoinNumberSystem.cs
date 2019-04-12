using System;
using System.Collections.Generic;
using Entitas;

public class CheckJoinNumberSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public CheckJoinNumberSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceMatchJoinedNumber(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MatchJoinedNumber);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMatchJoinedNumber;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (!_context.hasCurrentMatchData) return;

        foreach (var e in entities)
        {
            
            if (e.matchJoinedNumber.value != _context.currentMatchData.value.matchSize) continue;

            foreach (var ui in _context.GetEntitiesWithName("ReadyWindow"))
            {
                ui.ReplaceActive(true);
            }

            foreach (var ui in _context.GetEntitiesWithName("WaitOtherPlayerJoin"))
            {
                ui.ReplaceActive(false);
            }

            for (var i = 1; i <= e.matchJoinedNumber.value; i++)
            {
                foreach (var ui in _context.GetEntitiesWithName("Player" + i))
                {
                    ui.ReplaceActive(true);
                }
            }
        }
    }


}