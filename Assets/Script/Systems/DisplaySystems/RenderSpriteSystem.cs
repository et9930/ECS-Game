using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderSpriteSystem : ReactiveSystem<DisplayEntity>
{
    readonly DisplayContext _context; 

    public RenderSpriteSystem(Contexts contexts) : base(contexts.display)
    {
        _context = contexts.display;
    }
    
    protected override ICollector<DisplayEntity> GetTrigger(IContext<DisplayEntity> context)
    {
        return context.CreateCollector(DisplayMatcher.Sprite);
    }

    protected override bool Filter(DisplayEntity entity)
    {
        return entity.hasSprite && entity.hasView;
    }

    protected override void Execute(List<DisplayEntity> entities)
    {
        foreach (var e in entities)
        {
            GameObject go = e.view.gameObject;
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            if (sr == null)
                sr = go.AddComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>(e.sprite.path);
        }
    }    
}