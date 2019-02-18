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
        _context.ReplaceMouseInOutEventFunc(new Dictionary<string, Action>(), new Dictionary<string, Action>());
        _context.mouseInOutEventFunc.inDic["HealthValueTxt"] = HealthValueTxtOnMouseIn;
        _context.mouseInOutEventFunc.inDic["ChaKuRaValueImg"] = ChaKuRaValueImgOnMouseIn;
        _context.mouseInOutEventFunc.inDic["TaiRyoKuValueImg"] = TaiRyoKuValueImgOnMouseIn;

        _context.mouseInOutEventFunc.outDic["HealthValueTxt"] = HealthValueTxtOnMouseOut;
        _context.mouseInOutEventFunc.outDic["ChaKuRaValueImg"] = ChaKuRaValueImgOnMouseOut;
        _context.mouseInOutEventFunc.outDic["TaiRyoKuValueImg"] = TaiRyoKuValueImgOnMouseOut;

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
                    _context.mouseInOutEventFunc.inDic[e.name.text]();
                }
            }
            else
            {
                if (_context.mouseInOutEventFunc.outDic.ContainsKey(e.name.text))
                {
                    _context.mouseInOutEventFunc.outDic[e.name.text]();
                }
            }
        }
    }

    private void HealthValueTxtOnMouseIn()
    {
        foreach (var e in _context.GetEntities())
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "HealthPopUpWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void HealthValueTxtOnMouseOut()
    {
        foreach (var e in _context.GetEntities())
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "HealthPopUpWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }

    private void ChaKuRaValueImgOnMouseIn()
    {
        foreach (var e in _context.GetEntities())
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "ChaKuRaPopUpWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void ChaKuRaValueImgOnMouseOut()
    {
        foreach (var e in _context.GetEntities())
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "ChaKuRaPopUpWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }

    private void TaiRyoKuValueImgOnMouseIn()
    {
        foreach (var e in _context.GetEntities())
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "TaiRyoKuPopUpWindow") continue;

            e.ReplaceActive(true);
            return;
        }
    }

    private void TaiRyoKuValueImgOnMouseOut()
    {
        foreach (var e in _context.GetEntities())
        {
            if (!e.hasName || !e.hasActive) continue;
            if (e.name.text != "TaiRyoKuPopUpWindow") continue;

            e.ReplaceActive(false);
            return;
        }
    }
}