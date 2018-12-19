using System.Collections.Generic;
using Entitas;

public class SetMoveTargetSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _gameContext;

    public SetMoveTargetSystem(Contexts contexts) : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.RightMouse, GameMatcher.MouseDown));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isRightMouse && entity.hasMouseDown;
    }

    protected override void Execute(List<GameEntity> entities)
    {      
        foreach (var e in entities)
        {
            var players = _gameContext.GetEntities();            
            foreach (var player in players)
            {
                if (!player.hasAcceleration) continue;
                player.ReplaceMoveTarget(e.mouseDown.position);
                player.isChangingSpeed = true;
                player.isMoving = true;
            }
        }
    }
}