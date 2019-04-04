using System.Collections.Generic;
using Entitas;


public class AddViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly GameContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.viewService.instance.InitializeViewRoot("Game Views");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.isView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.CreateEntity().ReplaceDebugMessage(e.name.text + " add view");
            _context.viewService.instance.InitializeView(e, e.name.text);
            _context.viewService.instance.LoadSprite(e.name.text, e.sprite.path);
            e.isView = true;
        }
    }
}
