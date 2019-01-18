using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class AddPhysicalComponentSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddPhysicalComponentSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.InitializePhysical);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isInitializePhysical;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isInitializePhysical = false;
            e.ReplaceAcceleration(Vector3.Zero);
            e.ReplaceVelocity(Vector3.Zero);
        }
    }
}