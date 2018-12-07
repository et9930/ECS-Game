using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderSpriteSystem : MultiReactiveSystem<IViewableEntity, Contexts>
{
    readonly DisplayContext _context; 

    public RenderSpriteSystem(Contexts contexts) : base(contexts)
    {
        _context = contexts.display;
    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.player.CreateCollector(PlayerMatcher.Sprite),
            contexts.ninjutsu.CreateCollector(NinjutsuMatcher.Sprite)
        };
    }

    protected override bool Filter(IViewableEntity entity)
    {
        return entity.hasSprite && entity.hasView;
    }

    protected override void Execute(List<IViewableEntity> entities)
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