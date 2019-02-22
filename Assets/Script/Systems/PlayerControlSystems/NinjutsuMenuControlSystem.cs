﻿using System;
using System.Numerics;
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
        if (_context.key.value.NinjutsuAttackMenu)
        {
            if (_context.isNinjutsuMenuOpenFreezing) return;
            if (_context.movingUiList.list.Contains("NinjutsuMenu")) return;
            if (!_context.isNinjutsuMenuOpen)
            {
                _context.CreateEntity().ReplaceUiMoveAction("NinjutsuMenu", false, new Vector2(-960, -28), 0.3f);
                _context.isNinjutsuMenuOpen = true;
                _context.isNinjutsuMenuOpenFreezing = true;
                foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                {
                    if (!ui.hasName || ui.name.text != "NinjutsuMenuScrollbar") continue;
                    
                    ui.ReplaceScrollBarValue(0.0f);
                    break;
                }
            }
            else
            {
                _context.CreateEntity().ReplaceUiMoveAction("NinjutsuMenu", false, new Vector2(-960, -540), 0.3f);
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