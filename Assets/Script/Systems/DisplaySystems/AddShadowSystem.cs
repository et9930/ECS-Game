using System.Collections.Generic;
using Entitas;

public class AddShadowSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddShadowSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AddShadow);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAddShadow && !entity.isShadow;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var newShadow = _context.CreateEntity();
            newShadow.isShadow = true;
            newShadow.ReplaceId(e.id.value);
            newShadow.ReplaceName(e.name.text + " Shadow");
            newShadow.ReplaceHierarchy(e.hierarchy.value);
            var newShadowPosition = e.position.value;
            newShadowPosition.Y = 0;
            newShadow.ReplacePosition(newShadowPosition);
            newShadow.ReplaceToward(false);
            newShadow.ReplaceScale(e.scale.value);
            newShadow.ReplaceSprite("Image/Character/Shadow");
            e.isAddShadow = false;
        }
    }
}