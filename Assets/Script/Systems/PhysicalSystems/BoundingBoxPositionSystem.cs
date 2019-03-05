using System.Collections.Generic;
using Entitas;

public class BoundingBoxPositionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public BoundingBoxPositionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Sprite, GameMatcher.Position).NoneOf(GameMatcher.Shadow));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.isView && entity.hasName && entity.hasTag;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var position = e.position.value;
            var size = _context.viewService.instance.GetViewSize(e.name.text);
            var pivot = _context.viewService.instance.GetViewPivot(e.name.text);

            var MinX = position.X - size.X * pivot.X;
            var MaxX = position.X + size.X * (1 - pivot.X);

            var MinY = position.Y - size.Y * pivot.Y;
            if (MinY < 0)
            {
                MinY = 0;
            }
            var MaxY = position.Y + size.Y * (1 - pivot.Y);

            var MinZ = position.Z;
            var MaxZ = position.Z;
            if (e.tag.value == "Character")
            {
                MinZ -= 0.5f;
                MaxZ += 0.5f;
            }


            e.ReplaceBoundingBox(MinX, MinY, MinZ, MaxX, MaxY, MaxZ);
        }
    }
}