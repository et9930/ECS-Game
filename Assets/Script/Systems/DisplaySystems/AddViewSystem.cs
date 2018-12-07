using System.Collections.Generic;
using Entitas;
using UnityEngine;

public interface IViewableEntity : IEntity, IPositionEntity, ISpriteEntity, IViewEntity { }

public partial class PlayerEntity : IViewableEntity { }
public partial class NinjutsuEntity : IViewableEntity { }

public class AddViewSystem : MultiReactiveSystem<IViewableEntity, Contexts>
{
    readonly Transform _viewContainer = new GameObject("Game Views").transform;
    readonly DisplayContext _context;

    public AddViewSystem(Contexts contexts) : base(contexts)
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
        return entity.hasSprite && !entity.hasView;
    }

    protected override void Execute(List<IViewableEntity> entities)
    {
        foreach (var e in entities)
        {
            GameObject go = new GameObject("Player");
            go.transform.SetParent(_viewContainer);
            e.AddView(go);   
        }
    }
}
