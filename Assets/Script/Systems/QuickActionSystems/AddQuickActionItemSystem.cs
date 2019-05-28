using System;
using System.Collections.Generic;
using Entitas;

public class AddQuickActionItemSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddQuickActionItemSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AddQuickActionItem);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isAddQuickActionItem;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        _context.isAddQuickActionItem = false;
        var player = _context.GetEntityWithId(_context.currentPlayerId.value);

        GameEntity listEntity = null;
        GameEntity menuEntity = null;
        foreach (var e in _context.GetEntitiesWithName("QuickActionMenuList"))
        {
            listEntity = e;
            break;
        }

        foreach (var e in _context.GetEntitiesWithName("QuickActionMenu"))
        {
            menuEntity = e;
            break;
        }
        if (listEntity == null || menuEntity == null) return;

        GameEntity quickActionE = null;

        var qaNumber = 0;
        foreach (var quickActionEntity in _context.GetGroup(GameMatcher.QuickActionObject))
        {
            var testEntity = quickActionEntity;
            if (quickActionEntity.hasPerceptionTarget && quickActionEntity.mouseInState.value)
            {
                testEntity = quickActionEntity.perceptionTarget.value;
            }
            else
            {
                if (!testEntity.mouseInState.value) continue;
            }
            quickActionE = quickActionEntity;
            foreach (var quickAction in _context.quickActionConfig.list)
            {
                if (!quickAction.allNinja && !quickAction.requireNinja.Contains(player.name.text)) continue;
                if (!CheckRequireFlag(quickAction, testEntity)) continue;

                var item = _context.CreateEntity();
                item.ReplaceName("QuickActionMenuItem");
                item.ReplaceUiOpen("QuickActionMenuItem");
                item.ReplaceQuickActionItemConfig(quickAction);
                item.ReplaceParentEntity(listEntity);
                item.ReplaceQuickActionTarget(testEntity);
                    
                _context.CreateEntity().ReplaceDebugMessage(quickAction.describe);
                qaNumber++;
            }
        }

        if (qaNumber <= 0) return;

        var menuPosition = _context.mouseInputService.instance.GetMouseScreenPosition();

        if (menuPosition.X > _context.viewService.instance.ScreenSize.X - 166)
        {
            menuPosition.X = _context.viewService.instance.ScreenSize.X - 166;
        }

        if (menuPosition.Y > _context.viewService.instance.ScreenSize.Y - qaNumber * 60)
        {
            menuPosition.Y = _context.viewService.instance.ScreenSize.Y - qaNumber * 60;
        }

        if (quickActionE != null && !quickActionE.hasUiRootId)
        {
            menuEntity.ReplaceParentEntity(quickActionE);
            if (quickActionE.hasPosition)
            {
                menuEntity.ReplaceUiExcursion(menuPosition - _context.viewService.instance.WorldPositionToScreenPosition(quickActionE.position.value));
            }
        }
        else
        {
            _context.sceneService.instance.SetUIAnchoredPosition(menuEntity.name.text, _context.mouseInputService.instance.GetMouseScreenPosition());
        }

        _context.sceneService.instance.SetUIAnchoredPosition("QuickActionMenu", menuPosition);
        listEntity.ReplaceActive(true);
        _context.isQuickActionMenuOn = true;

    }

    private bool CheckRequireFlag(QuickAction qa, GameEntity e)
    {
        if (qa.requireFlag != null)
        {
            foreach (var trueFlag in qa.requireFlag)
            {
                var index = Array.IndexOf(GameComponentsLookup.componentNames, trueFlag);
                if (!e.HasComponent(index))
                    return false;
            }
        }

        if (qa.requireNoFlag != null)
        {
            foreach (var falseFlag in qa.requireNoFlag)
            {
                var index = Array.IndexOf(GameComponentsLookup.componentNames, falseFlag);
                if (e.HasComponent(index))
                    return false;
            }
        }

        return true;
    }
}