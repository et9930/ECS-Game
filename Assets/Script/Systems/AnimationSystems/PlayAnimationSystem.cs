using System;
using Entitas;

public class PlayAnimationSystem : IExecuteSystem , IInitializeSystem
{
    private readonly GameContext _context;

    public PlayAnimationSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceAnimationFrameRate(24);
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.AllOf(GameMatcher.CurrentAnimation, GameMatcher.AnimationFrame)))
        {

            var animationInfo = _context.imageAsset.imageInfos.infos[e.name.text].animationInfos[e.currentAnimation.name];
            var currentFrame = e.animationFrame.value;
            if (animationInfo.frameInfos.ContainsKey((int)currentFrame))
            {
                e.ReplaceSprite(animationInfo.frameInfos[(int)currentFrame].path);
            }

            currentFrame += _context.animationFrameRate.value / _context.currentFps.value;

            if (currentFrame > animationInfo.maxFrame && e.animation.loop)
            {
                currentFrame = 0;
            }
            else
            {
                e.ReplaceAnimation("idle", true);
            }

            e.ReplaceAnimationFrame(currentFrame);
        }
    }

}