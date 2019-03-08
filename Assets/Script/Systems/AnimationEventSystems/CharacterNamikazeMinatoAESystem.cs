using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class CharacterNamikazeMinatoAESystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CharacterNamikazeMinatoAESystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadPlayer);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadPlayer && entity.loadPlayer.playerName == "NamikazeMinato";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var characterDic = _context.animationEventFunc.characterDic;
        characterDic["NamikazeMinato"] = new CharacterEvent {animationDic = new Dictionary<string, AnimationEvent>()};
        var animationDic = characterDic["NamikazeMinato"].animationDic;

        //        // idle AE
        //        animationDic["idle"] = new AnimationEvent {frameDic = new Dictionary<int, Action>()};
        //
        //        var frameDic = animationDic["idle"].frameDic;
        //        frameDic[_context.imageAsset.imageInfos.infos["NamikazeMinato"].animationInfos["idle"].maxFrame] = OnMinatoIdleOver;

        // jump_0 AE
        animationDic["jump_0"] = new AnimationEvent() {frameDic = new Dictionary<int, Action<GameEntity>>()};

        var frameDic = animationDic["jump_0"].frameDic;
        frameDic[_context.imageAsset.imageInfos.infos["NamikazeMinato"].animationInfos["jump_0"].maxFrame] = OnMinatoStartJumpOver;

        // attack_1 AE
        animationDic["attack_1"] = new AnimationEvent() {frameDic = new Dictionary<int, Action<GameEntity>>()};

        frameDic = animationDic["attack_1"].frameDic;
        frameDic[10] = OnMinatoAttackPlayEffect;
        frameDic[11] = OnMinatoTaijutsuAttackCheck;
    }
    
//    public void OnMinatoIdleOver()
//    {
//        _context.CreateEntity().ReplaceDebugMessage("OnMinatoIdleOver");
//    }

    public void OnMinatoStartJumpOver(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("NamikazeMinato"))
        {
            if (e.isShadow || !e.hasAnimationFrame) continue;
            
            e.ReplaceAnimationFrame(e.animationFrame.value - 1);
        }
    }

    private void OnMinatoAttackPlayEffect(GameEntity entity)
    {
        var effectEntity = _context.CreateEntity();
        effectEntity.ReplaceName("Effect");
        effectEntity.ReplaceAnimation("attack_1", false);
        effectEntity.ReplaceParentEntity(entity);
        var position = entity.position.value;
        position.X += entity.toward.left ? 0.7f : -0.7f;
        position.Y += 1.0f;
        effectEntity.ReplacePosition(position);
        effectEntity.ReplaceScale(Vector2.One);
        effectEntity.ReplaceToward(entity.toward.left);
    }

    private void OnMinatoTaijutsuAttackCheck(GameEntity entity)
    {
        entity.isCheckTaijutsuAttackHit = true;
    }
}