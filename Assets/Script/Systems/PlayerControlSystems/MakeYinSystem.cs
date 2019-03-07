using System.Linq;
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
        _context.ReplaceMakeYinTime(3.0f);
        _context.ReplaceCurrentInNumber(0);
    }

    public void Execute()
    {
        if (!_context.hasCurrentPlayerId) return;

        foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
        {
            if (e.isShadow) continue;
            if (e.isNormalAttacking || e.isMakingChaKuRa || e.isJumping) continue;

            GameEntity yinListUi = null;

            if (e.isMakingYin)
            {
                var newValue = _context.makeYinTime.value - _context.timeService.instance.GetDeltaTime();
                if (newValue < 0.0f)
                {
                    newValue = 0.0f;
                }
                _context.ReplaceMakeYinTime(newValue);
            }

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjutsuYinList") continue;
                yinListUi = ui;
                break;
            }

            // Cancel Make Yin
            if (e.isMakingYin && _context.key.value.Cancel)
            {
                e.isMakingYin = false;
                foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                {
                    if (ui.name.text != "NinjutsuQTE") continue;

                    ui.ReplaceActive(false);
                    foreach (var childId in _context.uiChildList.dic[ui.uiRootId.value])
                    {
                        var closeUiEntity = _context.CreateEntity();
                        closeUiEntity.ReplaceUiRootId(childId);
                        closeUiEntity.isUiClose = true;
                    }
                    _context.uiChildList.dic[ui.uiRootId.value].Clear();
                    break;
                }
                e.yinList.list.Clear();
                _context.ReplaceMakeYinTime(3.0f);
                _context.ReplaceCurrentInNumber(0);
            }

            // Make Yin complete
            if (e.isMakingYin && ((_context.key.value.InComplete && !_context.yinFreeze.YinCompleteFreezing) || _context.makeYinTime.value == 0.0f))
            {
                // start ninjutsu
                _context.yinFreeze.YinCompleteFreezing = true;

                // check yin list
                foreach (var ninjutsuName in _context.characterBaseAttributes.dic[e.name.text].ninjutsuList)
                {
                    if (!e.yinList.list.SequenceEqual(_context.ninjutsuAttributes.dic[ninjutsuName].ninjutsuFullYin)) continue;

                    var jutsu = _context.CreateEntity();
                    jutsu.ReplaceName(ninjutsuName);
                    jutsu.isJutsu = true;
                    break;
                }

                // close ui
                e.isMakingYin = false;
                foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                {
                    if (ui.name.text != "NinjutsuQTE") continue;

                    ui.ReplaceActive(false);
                    foreach (var childId in _context.uiChildList.dic[ui.uiRootId.value])
                    {
                        var closeUiEntity = _context.CreateEntity();
                        closeUiEntity.ReplaceUiRootId(childId);
                        closeUiEntity.isUiClose = true;
                    }
                    _context.uiChildList.dic[ui.uiRootId.value].Clear();
                    break;
                }
                e.yinList.list.Clear();
                _context.ReplaceMakeYinTime(3.0f);
                _context.ReplaceCurrentInNumber(0);
            }

            if (!_context.key.value.InComplete && _context.yinFreeze.YinCompleteFreezing)
            {
                _context.yinFreeze.YinCompleteFreezing = false;
            }

            if (_context.key.value.In1 && !_context.yinFreeze.Yin1Freezing)
            {
                DealYinKeyDown("Zi", Yin.Zi, e, yinListUi);
                _context.yinFreeze.Yin1Freezing = true;
            }

            if (!_context.key.value.In1 && _context.yinFreeze.Yin1Freezing)
            {
                _context.yinFreeze.Yin1Freezing = false;
            }

            if (_context.key.value.In2 && !_context.yinFreeze.Yin2Freezing)
            {
                DealYinKeyDown("Yin", Yin.Yin, e, yinListUi);
                _context.yinFreeze.Yin2Freezing = true;
            }

            if (!_context.key.value.In2 && _context.yinFreeze.Yin2Freezing)
            {
                _context.yinFreeze.Yin2Freezing = false;
            }

            if (_context.key.value.In3 && !_context.yinFreeze.Yin3Freezing)
            {
                DealYinKeyDown("Chen", Yin.Chen, e, yinListUi);
                _context.yinFreeze.Yin3Freezing = true;
            }

            if (!_context.key.value.In3 && _context.yinFreeze.Yin3Freezing)
            {
                _context.yinFreeze.Yin3Freezing = false;
            }

            if (_context.key.value.In4 && !_context.yinFreeze.Yin4Freezing)
            {
                DealYinKeyDown("Wu", Yin.Wu, e, yinListUi);
                _context.yinFreeze.Yin4Freezing = true;
            }

            if (!_context.key.value.In4 && _context.yinFreeze.Yin4Freezing)
            {
                _context.yinFreeze.Yin4Freezing = false;
            }

            if (_context.key.value.In5 && !_context.yinFreeze.Yin5Freezing)
            {
                DealYinKeyDown("Shen", Yin.Shen, e, yinListUi);
                _context.yinFreeze.Yin5Freezing = true;

            }

            if (!_context.key.value.In5 && _context.yinFreeze.Yin5Freezing)
            {
                _context.yinFreeze.Yin5Freezing = false;
            }

            if (_context.key.value.In6 && !_context.yinFreeze.Yin6Freezing)
            {
                DealYinKeyDown("Xu", Yin.Xu, e, yinListUi);
                _context.yinFreeze.Yin6Freezing = true;

            }

            if (!_context.key.value.In6 && _context.yinFreeze.Yin6Freezing)
            {
                _context.yinFreeze.Yin6Freezing = false;
            }
        }
    }

    private void DealYinKeyDown(string yinName, Yin yin, GameEntity e, GameEntity yinListUi)
    {
        if (!e.isMakingYin)
        {
            e.isMakingYin = true;
            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjutsuQTE") continue;
                
                ui.ReplaceActive(true);
                break;
            }
        }

        e.yinList.list.Add(yin);
        e.ReplaceChaKuRaExpend(1.0f);

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