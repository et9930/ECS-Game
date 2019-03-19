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
        _context.clickEventFunc.clickDic["QuickActionMenuItem"] = OnQuickActionMenuItemClick;
        _context.clickEventFunc.clickDic["SelectTarget"] = OnSelectTargetClick;
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
            var uiName = e.name.text;
            var index = e.name.text.IndexOf('_');
            if (index != -1)
            {
                uiName = e.name.text.Substring(0, index);
            }
            if (_context.clickEventFunc.clickDic.ContainsKey(uiName))
            {
                _context.clickEventFunc.clickDic[uiName](e);
            }
        }
    }

    private void OnNinjaItemMenuItemClick(GameEntity entity)
    {
        if (entity.hasActive && entity.active.value) return;
        if (entity.leftNumber.value <= 0) return;

        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        currentPlayer.ReplaceUseNinjaItem(entity.ninjaItemName.value);
        
        foreach (var e in _context.GetEntitiesWithName("NinjaItemMenuItem"))
        {
            e.ReplaceActive(false);
        }

        entity.ReplaceActive(true);
    }

    private void OnQuickActionMenuItemClick(GameEntity entity)
    {
        _context.CreateEntity().ReplaceDebugMessage(entity.quickActionTarget.value.name.text);
    }

    private void OnSelectTargetClick(GameEntity entity)
    {
        entity.isSelected = true;
    }
}
