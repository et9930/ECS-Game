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

        // idle AE
        animationDic["idle"] = new AnimationEvent {frameDic = new Dictionary<int, Action>()};

        var frameDic = animationDic["idle"].frameDic;
        frameDic[_context.imageAsset.imageInfos.infos["Minato"].animationInfos["idle"].maxFrame] = OnMinatoIdleOver;

    }

    public void OnMinatoIdleOver()
    {
        _context.CreateEntity().ReplaceDebugMessage("OnMinatoIdleOver");
    }
}