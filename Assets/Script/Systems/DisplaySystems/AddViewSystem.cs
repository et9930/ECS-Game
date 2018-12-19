using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _viewContainer = new GameObject("Game Views").transform;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
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
            GameObject go = new GameObject("Player");
            go.transform.SetParent(_viewContainer);
            e.AddView(go);   
        }
    }
}
