using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class QuickActionMenuControlSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public QuickActionMenuControlSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.MouseDown, GameMatcher.MouseUp));
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.isLeftMouse && entity.hasMouseDown && _context.isQuickActionMenuOn) || (entity.isRightMouse && entity.hasMouseUp && !_context.isQuickActionMenuOn);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.currentScene.name != "BattleScene") return;
        foreach (var e in entities)
        {
            if (e.isRightMouse)
            {
                _context.isAddQuickActionItem = true;
            }
            else if (e.isLeftMouse)
            {
                GameEntity clickEntity = null;
                foreach (var ui in _context.GetEntitiesWithName("QuickActionMenuItem"))
                {
                    if (ui.mouseInState.value)
                    {
                        clickEntity = ui;
                    }
                    break;
                }

                if (clickEntity != null)
                {
                    var execEntity = _context.CreateEntity();
                    execEntity.ReplaceQuickActionItemConfig(clickEntity.quickActionItemConfig.value);
                    execEntity.ReplaceQuickActionTarget(clickEntity.quickActionTarget.value);
                    execEntity.isQuickActionExecute = true;
                }

                _context.isQuickActionMenuOn = false;
                GameEntity menuEntity = null;
                foreach (var ui in _context.GetEntitiesWithName("QuickActionMenu"))
                {
                    menuEntity = ui;
                    break;
                }
                if (menuEntity == null) return;

                foreach (var childId in _context.uiChildList.dic[menuEntity.uiRootId.value])
                {
                    var child = _context.CreateEntity();
                    child.ReplaceUiRootId(childId);
                    child.isUiClose = true;
                }
                _context.uiChildList.dic[menuEntity.uiRootId.value].Clear();
                if (menuEntity.hasParentEntity)
                {
                    menuEntity.RemoveParentEntity();
                }
                if (menuEntity.hasUiExcursion)
                {
                    menuEntity.RemoveUiExcursion();
                }
            }
        }
    }
}
