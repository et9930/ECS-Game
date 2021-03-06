﻿using System.Numerics;
using Entitas;

public class NinjutsuMenuControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public NinjutsuMenuControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.hasBattleOver) return;

        if (_context.currentScene.name != "BattleScene") return;
        if (_context.key.value.NinjutsuAttackMenu)
        {
            if (_context.isNinjutsuMenuOpenFreezing) return;
            if (_context.movingUiList.list.Contains("NinjutsuMenu")) return;

            GameEntity menu = null;

            foreach (var e in _context.GetEntitiesWithName("NinjutsuMenu"))
            {
                menu = e;
                break;
            }

            if (menu == null) return;

            if (!_context.isNinjutsuMenuOpen)
            {
                menu.ReplaceUiMoveAction("NinjutsuMenu", false, new Vector2(-960, -28), 0.3f);
                _context.isNinjutsuMenuOpen = true;
                _context.isNinjutsuMenuOpenFreezing = true;
                foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                {
                    if (!ui.hasName || ui.name.text != "NinjutsuMenuScrollbar") continue;
                    
                    ui.ReplaceScrollBarValue(1.0f);
                    break;
                }
            }
            else
            {
                menu.ReplaceUiMoveAction("NinjutsuMenu", false, new Vector2(-960, -540), 0.3f);
                _context.isNinjutsuMenuOpen = false;
                _context.isNinjutsuMenuOpenFreezing = true;
            }
        }
        else
        {
            if (_context.isNinjutsuMenuOpenFreezing)
            {
                _context.isNinjutsuMenuOpenFreezing = false;
            }
        }
    }
}