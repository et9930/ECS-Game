using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : ReactiveSystem<DisplayEntity>
{
    public RenderPositionSystem(Contexts contexts) : base(contexts.display)
    {
    }

    protected override ICollector<DisplayEntity> GetTrigger(IContext<DisplayEntity> context)
    {
        return context.CreateCollector(DisplayMatcher.Position);
    }

    protected override bool Filter(DisplayEntity entity)
    {
        return entity.hasPosition && entity.hasView;
    }

    protected override void Execute(List<DisplayEntity> entities)
    {
        foreach (var e in entities)
        {
            e.view.gameObject.transform.position = e.position.value;
        }
    }
}