using System;
using System.Collections.Generic;
using Entitas;

public class QuickActionExecuteSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public QuickActionExecuteSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceQuickActionExecuteFunc(new Dictionary<string, Action<GameEntity>>());
        _context.quickActionExecuteFunc.dic["MinatoHiRaiShinMaKinGu"] = ExecuteMinatoHiRaiShinMaKinGu;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.QuickActionExecute); 
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isQuickActionExecute;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasQuickActionItemConfig && _context.quickActionExecuteFunc.dic.ContainsKey(e.quickActionItemConfig.value.name))
            {
                _context.quickActionExecuteFunc.dic[e.quickActionItemConfig.value.name](e);
            }
        }
    }

    private void ExecuteMinatoHiRaiShinMaKinGu(GameEntity entity)
    {
        var e = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (e == null) return;
        if (e.isDead) return;
        if (!e.isMakingYin)
        {
            e.isMakingYin = true;
            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (!ui.hasName) continue;
                if (ui.name.text != "NinjutsuQTE") continue;

                ui.ReplaceActive(true);
                break;
            }

            var beforeJutsu = _context.CreateEntity();
            beforeJutsu.isBeforeJutsuTarget = true;
            beforeJutsu.ReplaceName("HiRaiShinNoJuTsu");
            beforeJutsu.ReplaceJutsuTarget(entity.quickActionTarget.value);
        }

        entity.isDestroy = true;
    }

}