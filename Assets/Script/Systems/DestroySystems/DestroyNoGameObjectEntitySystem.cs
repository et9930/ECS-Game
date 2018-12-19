using System.Collections.Generic;
using Entitas;

public class DestroyNoGameObjectEntitySystem : ReactiveSystem<GameEntity>
{
    public DestroyNoGameObjectEntitySystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
            //context.CreateCollector(GameMatcher),
        return context.CreateCollector(GameMatcher.Destroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.Destroy();
        }
    }
}
