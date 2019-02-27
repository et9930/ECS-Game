using System;
using System.Collections.Generic;
using Entitas;

public class MouseInOutEventSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public MouseInOutEventSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceMouseInOutEventFunc(new Dictionary<string, Action<GameEntity>>(), new Dictionary<string, Action<GameEntity>>());
        _context.mouseInOutEventFunc.inDic["HealthValueTxt"] = HealthValueTxtOnMouseIn;
        _context.mouseInOutEventFunc.inDic["ChaKuRaValueImg"] = ChaKuRaValueImgOnMouseIn;
        _context.mouseInOutEventFunc.inDic["TaiRyoKuValueImg"] = TaiRyoKuValueImgOnMouseIn;
        _context.mouseInOutEventFunc.inDic["NinjutsuMenuItem"] = NinjutsuMenuItemOnMouseIn;
        _context.mouseInOutEventFunc.inDic["NinjaItemMenuItem"] = NinjaItemMenuItemOnMouseIn;

        _context.mouseInOutEventFunc.outDic["HealthValueTxt"] = HealthValueTxtOnMouseOut;
        _context.mouseInOutEventFunc.outDic["ChaKuRaValueImg"] = ChaKuRaValueImgOnMouseOut;
        _context.mouseInOutEventFunc.outDic["TaiRyoKuValueImg"] = TaiRyoKuValueImgOnMouseOut;
        _context.mouseInOutEventFunc.outDic["NinjutsuMenuItem"] = NinjutsuMenuItemOnMouseOut;
        _context.mouseInOutEventFunc.outDic["NinjaItemMenuItem"] = NinjaItemMenuItemOnMouseOut;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MouseInState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMouseInState;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.mouseInState.value)
            {
                if (_context.mouseInOutEventFunc.inDic.ContainsKey(e.name.text))
                {
                    _context.mouseInOutEventFunc.inDic[e.name.text](e);
                }
            }
            else
            {
                if (_context.mouseInOutEventFunc.outDic.ContainsKey(e.name.text))
                {
                    _context.mouseInOutEventFunc.outDic[e.name.text](e);
                }
            }
        }
    }

    private void HealthValueTxtOnMouseIn(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "HealthPopUpWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void HealthValueTxtOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "HealthPopUpWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }

    private void ChaKuRaValueImgOnMouseIn(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "ChaKuRaPopUpWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void ChaKuRaValueImgOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "ChaKuRaPopUpWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }

    private void TaiRyoKuValueImgOnMouseIn(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "TaiRyoKuPopUpWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void TaiRyoKuValueImgOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "TaiRyoKuPopUpWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }

    private void NinjutsuMenuItemOnMouseIn(GameEntity entity)
    {
//        if (!_context.isNinjutsuMenuOpen) return;

        _context.ReplacePointNinjutsuMenuItem(entity.ninjutsuName.value);
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "NinjutsuMenuInfoWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void NinjutsuMenuItemOnMouseOut(GameEntity entity)
    {
//        if (!_context.isNinjutsuMenuOpen) return;

        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "NinjutsuMenuInfoWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }

    private void NinjaItemMenuItemOnMouseIn(GameEntity entity)
    {
        _context.ReplacePointNinjaItemMenuItem(entity.ninjaItemName.value);
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "NinjaItemMenuInfoWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void NinjaItemMenuItemOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetGroup(GameMatcher.UiRootId))
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "NinjaItemMenuInfoWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }
}