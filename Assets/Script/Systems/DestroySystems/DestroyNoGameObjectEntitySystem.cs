using System.Collections.Generic;
using Entitas;

public class DestroyEntitisSystem : ReactiveSystem<GameEntity>
{
    public DestroyEntitisSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
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
            if (e.isLinked)
            {
                
            }
            e.Destroy();
        }
    }
}
