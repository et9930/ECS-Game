﻿using System.Numerics;
using Entitas;

public class UiFollowSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public UiFollowSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.ParentEntity))
        {
            if (!e.hasUiRootId) continue;
            if (!e.parentEntity.value.hasPosition) continue;

            var parentPosition = e.parentEntity.value.position.value;
//            _context.CreateEntity().ReplaceDebugMessage("parentPosition " + parentPosition);
            var parentScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(parentPosition);
//            _context.CreateEntity().ReplaceDebugMessage("parentScreenPosition " + parentScreenPosition);
//            parentScreenPosition.X -= _context.viewService.instance.ScreenSize.X / 2;
            if (e.hasUiExcursion)
            {
                parentScreenPosition += e.uiExcursion.value;
            }
//            parentScreenPosition.Y -= _context.viewService.instance.ScreenSize.Y / 2;
//            _context.CreateEntity().ReplaceDebugMessage("ScreenSize " + _context.viewService.instance.ScreenSize);
            _context.sceneService.instance.SetUILocalPosition(e.name.text, Vector2.Zero);
            _context.sceneService.instance.SetUIAnchoredPosition(e.name.text, parentScreenPosition);
        }
    }
}