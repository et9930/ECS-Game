using System;
using System.Collections.Generic;
using Entitas;

public class EffectAESystem : IInitializeSystem
{
    private readonly GameContext _context;

    public EffectAESystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var characterDic = _context.animationEventFunc.characterDic;
        characterDic["Effect"] = new CharacterEvent { animationDic = new Dictionary<string, AnimationEvent>() };
        var animationDic = characterDic["Effect"].animationDic;

        animationDic["attack_1"] = new AnimationEvent() { frameDic = new Dictionary<int, Action<GameEntity>>() };

        var frameDic = animationDic["attack_1"].frameDic;
        frameDic[_context.imageAsset.infos["Effect"].animationInfos["attack_1"].maxFrame] = OnEffectAttack1Over;
    }

    private void OnEffectAttack1Over(GameEntity entity)
    {
        entity.isDestroy = true;
    }
}