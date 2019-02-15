using System;
using System.Collections.Generic;
using Entitas;

public class CharacterMinatoAESystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CharacterMinatoAESystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadPlayer);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadPlayer && entity.loadPlayer.playerName == "Minato";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var characterDic = _context.animationEventFunc.characterDic;
        characterDic["Minato"] = new CharacterEvent {animationDic = new Dictionary<string, AnimationEvent>()};
        var animationDic = characterDic["Minato"].animationDic;

//        // idle AE
//        animationDic["idle"] = new AnimationEvent {frameDic = new Dictionary<int, Action>()};
//
//        var frameDic = animationDic["idle"].frameDic;
//        frameDic[_context.imageAsset.imageInfos.infos["Minato"].animationInfos["idle"].maxFrame] = OnMinatoIdleOver;

        // jump AE
        animationDic["jump_0"] = new AnimationEvent() {frameDic = new Dictionary<int, Action>()};

        var frameDic = animationDic["jump_0"].frameDic;
        frameDic[_context.imageAsset.imageInfos.infos["Minato"].animationInfos["jump_0"].maxFrame] = OnMinatoStartJumpOver;

    }

    public void OnMinatoIdleOver()
    {
//        _context.CreateEntity().ReplaceDebugMessage("OnMinatoIdleOver");
    }

    public void OnMinatoStartJumpOver()
    {
        foreach (var e in _context.GetGroup(GameMatcher.Id))
        {
            if (!e.hasName || e.name.text != "Minato" || e.isShadow) continue;
            if (!e.hasAnimationFrame) continue;
            
            e.ReplaceAnimationFrame(e.animationFrame.value - 1);
        }
    }
}