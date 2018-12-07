using System.Collections.Generic;
using Entitas;

public class SetMoveTargetSystem : ReactiveSystem<InputEntity>
{
    readonly InputContext inputContext;
    readonly PlayerContext playerContext;

    public SetMoveTargetSystem(Contexts contexts) : base(contexts.input)
    {
        inputContext = contexts.input;
        playerContext = contexts.player;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isRightMouse && entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {      
        foreach (var e in entities)
        {
            var players = playerContext.GetEntities();            
            foreach (var player in players)
            {
                if (player.hasAcceleration)
                {
                    player.ReplaceMoveTarget(e.mouseDown.position);
                    player.isChangingSpeed = true;
                    player.isMoving = true;
                }
            }
        }
    }
}