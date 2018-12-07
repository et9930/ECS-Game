using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : MultiReactiveSystem<IViewableEntity, Contexts>
{
    public RenderPositionSystem(Contexts contexts) : base(contexts)
    {
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.player.CreateCollector(PlayerMatcher.Position),
            contexts.ninjutsu.CreateCollector(NinjutsuMatcher.Position)
        };
    }

    protected override bool Filter(IViewableEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override void Execute(List<IViewableEntity> entities)
    {
        foreach (var e in entities)
        {
            e.view.gameObject.transform.position = e.position.value;
        }
    }
}