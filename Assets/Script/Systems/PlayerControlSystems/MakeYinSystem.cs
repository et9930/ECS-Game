using System.Numerics;
using Entitas;

public class MakeYinSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;

    public MakeYinSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceYinFreeze(false, false, false, false, false, false, false);
        _context.ReplaceMakeYinTime(0.0f);
        _context.ReplaceCurrentInNumber(0);
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.Id))
        {
            if (e.id.value != _context.currentPlayerId.value) continue;
            if (e.isShadow) continue;
            if (e.isNormalAttacking || e.isMakingChaKuRa) continue;

            GameEntity yinListUi = null;

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjutsuYinList") continue;
                yinListUi = ui;
                break;
            }

            if (e.isMakingYin && _context.key.value.InComplete && !_context.yinFreeze.YinCompleteFreezing)
            {
                // start ninjutsu
                _context.yinFreeze.YinCompleteFreezing = true;
            }

            if (!_context.key.value.InComplete && _context.yinFreeze.YinCompleteFreezing)
            {
                _context.yinFreeze.YinCompleteFreezing = false;
            }

            if (_context.key.value.In1 && !_context.yinFreeze.Yin1Freezing)
            {
                DealKeyDown("Zi", Yin.Zi, e, yinListUi);
                _context.yinFreeze.Yin1Freezing = true;
            }

            if (!_context.key.value.In1 && _context.yinFreeze.Yin1Freezing)
            {
                _context.yinFreeze.Yin1Freezing = false;
            }

            if (_context.key.value.In2 && !_context.yinFreeze.Yin2Freezing)
            {
                DealKeyDown("Yin", Yin.Yin, e, yinListUi);
                _context.yinFreeze.Yin2Freezing = true;
            }

            if (!_context.key.value.In2 && _context.yinFreeze.Yin2Freezing)
            {
                _context.yinFreeze.Yin2Freezing = false;
            }

            if (_context.key.value.In3 && !_context.yinFreeze.Yin3Freezing)
            {
                DealKeyDown("Chen", Yin.Chen, e, yinListUi);
                _context.yinFreeze.Yin3Freezing = true;
            }

            if (!_context.key.value.In3 && _context.yinFreeze.Yin3Freezing)
            {
                _context.yinFreeze.Yin3Freezing = false;
            }

            if (_context.key.value.In4 && !_context.yinFreeze.Yin4Freezing)
            {
                DealKeyDown("Wu", Yin.Wu, e, yinListUi);
                _context.yinFreeze.Yin4Freezing = true;
            }

            if (!_context.key.value.In4 && _context.yinFreeze.Yin4Freezing)
            {
                _context.yinFreeze.Yin4Freezing = false;
            }

            if (_context.key.value.In5 && !_context.yinFreeze.Yin5Freezing)
            {
                DealKeyDown("Shen", Yin.Shen, e, yinListUi);
                _context.yinFreeze.Yin5Freezing = true;

            }

            if (!_context.key.value.In5 && _context.yinFreeze.Yin5Freezing)
            {
                _context.yinFreeze.Yin5Freezing = false;
            }

            if (_context.key.value.In6 && !_context.yinFreeze.Yin6Freezing)
            {
                DealKeyDown("Xu", Yin.Xu, e, yinListUi);
                _context.yinFreeze.Yin6Freezing = true;

            }

            if (!_context.key.value.In6 && _context.yinFreeze.Yin6Freezing)
            {
                _context.yinFreeze.Yin6Freezing = false;
            }
        }
    }

    private void DealKeyDown(string yinName, Yin yin, GameEntity e, GameEntity yinListUi)
    {
        if (!e.isMakingYin)
        {
            e.isMakingYin = true;
            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjutsuQTE") continue;
                
                ui.ReplaceActive(true);
            }
        }

        e.yinList.list.Add(yin);

        var uiName = "NinjutsuYin" + yinName + _context.currentInNumber.value;
        var yinUI = _context.CreateEntity();
        yinUI.ReplaceName(uiName);
        yinUI.ReplaceParentEntity(yinListUi);
        yinUI.ReplaceUiOpen("NinjutsuYin" + yinName);
        yinUI.ReplaceUiMoveAction(uiName, false, new Vector2(_context.currentInNumber.value * 100, 0), 0.5f * (9 - _context.currentInNumber.value) / 9);
        yinUI.ReplaceUiFadeAction(uiName, 1.0f, 0.2f);

        _context.ReplaceCurrentInNumber(_context.currentInNumber.value + 1);
    }
}