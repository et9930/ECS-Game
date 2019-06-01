using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class CharacterUchihaMadaraAESystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CharacterUchihaMadaraAESystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadPlayer);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadPlayer && entity.loadPlayer.playerName == "UchihaMadara";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var characterDic = _context.animationEventFunc.characterDic;
        characterDic["UchihaMadara"] = new CharacterEvent {animationDic = new Dictionary<string, AnimationEvent>()};
        var animationDic = characterDic["UchihaMadara"].animationDic;

        // attack_1 AE
        animationDic["attack_1"] = new AnimationEvent() {frameDic = new Dictionary<int, Action<GameEntity>>()};

        var frameDic = animationDic["attack_1"].frameDic;
        frameDic[19] = OnUchihaMadaraTaijutsuAttackCheck;

    }

    private void OnUchihaMadaraTaijutsuAttackCheck(GameEntity entity)
    {
        entity.isCheckTaijutsuAttackHit = true;
    }
}