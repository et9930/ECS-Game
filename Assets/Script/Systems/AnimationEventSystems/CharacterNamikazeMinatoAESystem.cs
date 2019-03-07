using System;
using System.Collections.Generic;
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

        // jump AE
        animationDic["jump_0"] = new AnimationEvent() {frameDic = new Dictionary<int, Action>()};

        var frameDic = animationDic["jump_0"].frameDic;
        frameDic[_context.imageAsset.imageInfos.infos["NamikazeMinato"].animationInfos["jump_0"].maxFrame] = OnMinatoStartJumpOver;

    }

    public void OnMinatoIdleOver()
    {
//        _context.CreateEntity().ReplaceDebugMessage("OnMinatoIdleOver");
    }

    public void OnMinatoStartJumpOver()
    {
        foreach (var e in _context.GetEntitiesWithName("NamikazeMinato"))
        {
            if (e.isShadow || !e.hasAnimationFrame) continue;
            
            e.ReplaceAnimationFrame(e.animationFrame.value - 1);
        }
    }
}