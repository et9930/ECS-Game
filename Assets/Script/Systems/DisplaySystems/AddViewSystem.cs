using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _viewContainer = new GameObject("Game Views").transform;
    private readonly Contexts _contexts;
    private readonly GameContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
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
        return entity.hasSprite && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.viewService.instance.LoadAsset(_contexts, e, e.sprite.path);
        }
    }
}
