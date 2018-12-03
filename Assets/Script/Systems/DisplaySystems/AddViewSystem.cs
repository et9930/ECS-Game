using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : ReactiveSystem<DisplayEntity>
{
    readonly Transform _viewContainer = new GameObject("Game Views").transform;
    readonly DisplayContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts.display)
    {
        _context = contexts.display;
    }

    protected override ICollector<DisplayEntity> GetTrigger(IContext<DisplayEntity> context)
    {
        return context.CreateCollector(DisplayMatcher.Sprite);
    }

    protected override bool Filter(DisplayEntity entity)
    {
        return entity.hasSprite && !entity.hasView;
    }

    protected override void Execute(List<DisplayEntity> entities)
    {
        foreach (var e in entities)
        {
            GameObject go = new GameObject("Game Object");
            go.transform.SetParent(_viewContainer);
            e.AddView(go);   
        }
    } 

    
}
