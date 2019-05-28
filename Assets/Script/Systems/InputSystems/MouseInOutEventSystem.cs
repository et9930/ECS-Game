using System;
using System.Collections.Generic;
using System.Numerics;
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
        _context.mouseInOutEventFunc.inDic["SelectTarget"] = SelectTargetOnMouseIn;

        _context.mouseInOutEventFunc.outDic["HealthValueTxt"] = HealthValueTxtOnMouseOut;
        _context.mouseInOutEventFunc.outDic["ChaKuRaValueImg"] = ChaKuRaValueImgOnMouseOut;
        _context.mouseInOutEventFunc.outDic["TaiRyoKuValueImg"] = TaiRyoKuValueImgOnMouseOut;
        _context.mouseInOutEventFunc.outDic["NinjutsuMenuItem"] = NinjutsuMenuItemOnMouseOut;
        _context.mouseInOutEventFunc.outDic["NinjaItemMenuItem"] = NinjaItemMenuItemOnMouseOut;
        _context.mouseInOutEventFunc.outDic["SelectTarget"] = SelectTargetOnMouseOut;

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
            if (!e.hasUiName) continue;

            var uiName = e.uiName.value;
            if (e.mouseInState.value)
            {
                if (_context.mouseInOutEventFunc.inDic.ContainsKey(uiName))
                {
                    _context.mouseInOutEventFunc.inDic[uiName](e);
                }
            }
            else
            {
                if (_context.mouseInOutEventFunc.outDic.ContainsKey(uiName))
                {
                    _context.mouseInOutEventFunc.outDic[uiName](e);
                }
            }
        }
    }

    private void HealthValueTxtOnMouseIn(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("HealthPopUpWindow"))
        {
            e.ReplaceActive(true);
            return;
        }
    }

    private void HealthValueTxtOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("HealthPopUpWindow"))
        {
            e.ReplaceActive(false);
            return;
        }
    }

    private void ChaKuRaValueImgOnMouseIn(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("ChaKuRaPopUpWindow"))
        {
            e.ReplaceActive(true);
            return;
        }
    }

    private void ChaKuRaValueImgOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("ChaKuRaPopUpWindow"))
        {
            e.ReplaceActive(false);
            return;
        }
    }

    private void TaiRyoKuValueImgOnMouseIn(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("TaiRyoKuPopUpWindow"))
        {
            e.ReplaceActive(true);
            return;
        }
    }

    private void TaiRyoKuValueImgOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("TaiRyoKuPopUpWindow"))
        {
            e.ReplaceActive(false);
            return;
        }
    }

    private void NinjutsuMenuItemOnMouseIn(GameEntity entity)
    {
        _context.ReplacePointNinjutsuMenuItem(entity.ninjutsuName.value);

        foreach (var e in _context.GetEntitiesWithName("NinjutsuMenuInfoWindow"))
        {
            e.ReplaceActive(true);
            return;
        }
    }

    private void NinjutsuMenuItemOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("NinjutsuMenuInfoWindow"))
        {
            e.ReplaceActive(false);
            return;
        }
    }

    private void NinjaItemMenuItemOnMouseIn(GameEntity entity)
    {
        _context.ReplacePointNinjaItemMenuItem(entity.ninjaItemName.value);

        foreach (var e in _context.GetEntitiesWithName("NinjaItemMenuInfoWindow"))
        {
            e.ReplaceActive(true);
            return;
        }
    }

    private void NinjaItemMenuItemOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("NinjaItemMenuInfoWindow"))
        {
            e.ReplaceActive(false);
            return;
        }
    }

    private void SelectTargetOnMouseIn(GameEntity entity)
    {
        if (!entity.parentEntity.value.hasUiRootId) return;

        foreach (var e in _context.GetEntitiesWithName("OutScreenSelectTargetViewCamera"))
        {
            var position = entity.selectTarget.value.position.value;
            if (position.Z < -2.05f)
            {
                position.Z = -2.05f;
            }
            e.ReplacePosition(position);
        }

        foreach (var e in _context.GetEntitiesWithName("OutScreenSelectTargetView"))
        {
            e.ReplaceActive(true);
        }

    }

    private void SelectTargetOnMouseOut(GameEntity entity)
    {
        foreach (var e in _context.GetEntitiesWithName("OutScreenSelectTargetView"))
        {
            e.ReplaceActive(false);
        }
    }

}