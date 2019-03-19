using System;
using System.Numerics;
using Entitas;

public class NinjaItemMenuControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public NinjaItemMenuControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (_context.key.value.NinjaItemMenu)
        {
            if (_context.isNinjaItemMenuOpenFreezing) return;
            if (_context.movingUiList.list.Contains("NinjaItemMenu")) return;

            GameEntity menu = null;

            foreach (var e in _context.GetEntitiesWithName("NinjaItemMenu"))
            {
                menu = e;
                break;
            }

            if (menu == null) return;

            if (!_context.isNinjaItemMenuOpen)
            {
                menu.ReplaceUiMoveAction("NinjaItemMenu", true, new Vector2(0, 280), 0.3f);
                _context.isNinjaItemMenuOpen = true;
                _context.isNinjaItemMenuOpenFreezing = true;
            }
            else
            {
                menu.ReplaceUiMoveAction("NinjaItemMenu", true, new Vector2(0, -280), 0.3f);
                _context.isNinjaItemMenuOpen = false;
                _context.isNinjaItemMenuOpenFreezing = true;
            }
        }
        else
        {
            if (_context.isNinjaItemMenuOpenFreezing)
            {
                _context.isNinjaItemMenuOpenFreezing = false;
            }
        }

        if (_context.isNinjaItemMenuOpen)
        {
            GameEntity menu = null;

            foreach (var e in _context.GetEntitiesWithName("NinjaItemMenu"))
            {
                menu = e;
                break;
            }

            if (menu == null) return;

            if (!menu.mouseInState.value) return;
            if(_context.key.value.MouseScroll == 0.0f) return;

            menu.ReplaceUiRotateAction("NinjaItemMenu", 60.0f * _context.key.value.MouseScroll, 0.3f * Math.Abs(_context.key.value.MouseScroll));
        }
    }
}