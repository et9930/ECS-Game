using System.Collections.Generic;
using Entitas;

public class CreatePlayerSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CreatePlayerSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.LeftMouse, GameMatcher.MouseDown));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isLeftMouse && entity.hasMouseDown;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var player = _context.CreateEntity();
            player.AddPosition(e.mouseDown.position);
            player.AddMoveTarget(e.mouseDown.position);
            player.AddSprite(_context.imageAssetEntity.imageAsset.infos.infos[0].animationInfos[0].frameInfos[0].path);
            player.AddMaxSpeed(30);
            player.AddAcceleration(5);
            player.AddSpeed(0);
        }
    }

    

    
}
