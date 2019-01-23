using System;
using System.Collections.Generic;
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
        _context.ReplaceAnimationEventFunc(new Dictionary<string, CharacterEvent>());
        _context.ReplaceAnimationFrameRate(24);
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.AllOf(GameMatcher.CurrentAnimation, GameMatcher.AnimationFrame)))
        {

            var animationInfo = _context.imageAsset.imageInfos.infos[e.name.text].animationInfos[e.currentAnimation.name];
            Dictionary<int, Action> animationEventInfo = null;
            if (_context.animationEventFunc.characterDic.ContainsKey(e.name.text))
            {
                if (_context.animationEventFunc.characterDic[e.name.text].animationDic.ContainsKey(e.currentAnimation.name))
                {
                    animationEventInfo = _context.animationEventFunc.characterDic[e.name.text].animationDic[e.currentAnimation.name].frameDic;
                }
            }

            var lastFrame = e.animationFrame.value;
            var currentFrame = lastFrame + _context.animationFrameRate.value / _context.currentFps.value; ;

            if (animationInfo.frameInfos.ContainsKey((int)currentFrame))
            {
                e.ReplaceSprite(animationInfo.frameInfos[(int)currentFrame].path);
            }

            if (animationEventInfo != null)
            {
                if (animationEventInfo.ContainsKey((int)currentFrame) && (int)lastFrame != (int)currentFrame)
                {
                    animationEventInfo[(int)currentFrame]();
                }
            }
            
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