using System.Collections.Generic;
using Entitas;

public class ReplayMatchRecordSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReplayMatchRecordSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }
}