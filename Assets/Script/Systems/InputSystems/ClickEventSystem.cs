using System;
using Entitas;
using System.Collections.Generic;

public class ClickEventSystem : ReactiveSystem<GameEntity>, IInitializeSystem 
{
    private readonly GameContext _context;

    public ClickEventSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceClickEventFunc(new Dictionary<string, Action<GameEntity>>());
        _context.clickEventFunc.clickDic["NinjaItemMenuItem"] = OnNinjaItemMenuItemClick;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ClickState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasClickState && entity.clickState.value;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceClickState(false);
            if (_context.clickEventFunc.clickDic.ContainsKey(e.name.text))
            {
                _context.clickEventFunc.clickDic[e.name.text](e);
            }
        }
    }

    private void OnNinjaItemMenuItemClick(GameEntity entity)
    {
        if (entity.hasActive && entity.active.value) return;
             
        foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
        {
            if (e.isShadow) continue;

            e.ReplaceUseNinjaItem(entity.ninjaItemName.value);
        }

        foreach (var e in _context.GetEntitiesWithName("NinjaItemMenuItem"))
        {
            e.ReplaceActive(false);
        }

        entity.ReplaceActive(true);
    }

}
