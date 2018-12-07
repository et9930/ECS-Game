using System.Collections.Generic;
using Entitas;

public class CreatePlayerSystem : ReactiveSystem<InputEntity>
{
    readonly InputContext inputContext;
    readonly PlayerContext playerContext;

    public CreatePlayerSystem(Contexts contexts) : base(contexts.input)
    {
        playerContext = contexts.player;
        inputContext = contexts.input;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isLeftMouse && entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            PlayerEntity player = playerContext.CreateEntity();
            player.AddPosition(e.mouseDown.position);
            player.AddMoveTarget(e.mouseDown.position);
            player.AddSprite(inputContext.imageAssetEntity.imageAsset.infos.infos[0].animationInfos[0].frameInfos[0].path);
            player.AddMaxSpeed(30);
            player.AddAcceleration(5);
            player.AddSpeed(0);
        }
    }

    

    
}
