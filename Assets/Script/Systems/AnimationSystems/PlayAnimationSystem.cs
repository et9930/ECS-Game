using System;
using System.Collections.Generic;
using System.Numerics;
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
            Dictionary<int, Action<GameEntity>> animationEventInfo = null;
            if (_context.animationEventFunc.characterDic.ContainsKey(e.name.text))
            {
                if (_context.animationEventFunc.characterDic[e.name.text].animationDic.ContainsKey(e.currentAnimation.name))
                {
                    animationEventInfo = _context.animationEventFunc.characterDic[e.name.text].animationDic[e.currentAnimation.name].frameDic;
                }
            }

            var lastFrame = e.animationFrame.value;
            var currentFrame = lastFrame + _context.animationFrameRate.value / _context.currentFps.value;

            if (animationInfo.frameInfos.ContainsKey((int)currentFrame) && (int)lastFrame != (int)currentFrame)
            {
                // change sprite
                e.ReplaceSprite(animationInfo.frameInfos[(int)currentFrame].path);
                // add force
                if (animationInfo.frameInfos[(int)currentFrame].force.value != Vector3.Zero)
                {
                    _context.CreateEntity().ReplaceDebugMessage(e.name.text + " add animation force");
                    var force = animationInfo.frameInfos[(int) currentFrame].force;
                    var forceValue = force.value;
                    if (force.direction != e.toward.left)
                    {
                        forceValue.X = -forceValue.X;
                    }
                    e.ReplaceAddForce(forceValue, force.duration);
                }
            }

            // animation event
            if (animationEventInfo != null)
            {
                if (animationEventInfo.ContainsKey((int)currentFrame) && (int)lastFrame != (int)currentFrame)
                {
                    //_context.CreateEntity().ReplaceDebugMessage(e.name.text + " animation event");
                    animationEventInfo[(int)currentFrame](e);
                }
            }

            // animation end
            currentFrame = e.animationFrame.value + _context.animationFrameRate.value / _context.currentFps.value;

            if (currentFrame > animationInfo.maxFrame)
            {
                if (e.hasNextAnimation)
                {
                    e.ReplaceAnimation(e.nextAnimation.value, e.nextAnimation.loop);
                    e.RemoveNextAnimation();
                }
                else if (e.animation.loop)
                {
                    currentFrame = 0;
                }
                else
                {
                    e.ReplaceAnimation("idle", true);
                }
            }


            e.ReplaceAnimationFrame(currentFrame);
        }
    }

}