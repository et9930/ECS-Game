using System.Collections.Generic;
using Entitas;

public class ChangeViewSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly GameContext _context;

    public ChangeViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.isView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.viewService.instance.LoadSprite(e.name.text, e.sprite.path);
        }
    }
}