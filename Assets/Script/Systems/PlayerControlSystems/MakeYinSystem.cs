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
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null) return;

        if (currentPlayer.isNormalAttacking || currentPlayer.isMakingChaKuRa || currentPlayer.isJumping) return;

        GameEntity yinListUi = null;

        if (currentPlayer.isMakingYin)
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
        if (currentPlayer.isMakingYin && _context.key.value.Cancel)
        {
            currentPlayer.isMakingYin = false;
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
            currentPlayer.yinList.list.Clear();
            _context.ReplaceMakeYinTime(3.0f);
            _context.ReplaceCurrentInNumber(0);
        }

        // Make Yin complete
        if (currentPlayer.isMakingYin && ((_context.key.value.InComplete && !_context.yinFreeze.YinCompleteFreezing) || _context.makeYinTime.value == 0.0f))
        {
            // start ninjutsu
            _context.yinFreeze.YinCompleteFreezing = true;

            // check yin list
            foreach (var ninjutsuName in _context.characterBaseAttributes.dic[currentPlayer.name.text].ninjutsuList)
            {
                if (!currentPlayer.yinList.list.SequenceEqual(_context.ninjutsuAttributes.dic[ninjutsuName].ninjutsuFullYin)) continue;

                if (CheckJutsuAlreadyExist(ninjutsuName, currentPlayer))
                {
                    break;
                }

                var jutsu = _context.CreateEntity();
                jutsu.ReplaceName(ninjutsuName);
                jutsu.ReplaceOriginator(currentPlayer);
                jutsu.isJutsu = true;
                break;
            }

            // close ui
            currentPlayer.isMakingYin = false;
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
            currentPlayer.yinList.list.Clear();
            _context.ReplaceMakeYinTime(3.0f);
            _context.ReplaceCurrentInNumber(0);
        }

        if (!_context.key.value.InComplete && _context.yinFreeze.YinCompleteFreezing)
        {
            _context.yinFreeze.YinCompleteFreezing = false;
        }

        if (_context.key.value.In1 && !_context.yinFreeze.Yin1Freezing)
        {
            DealYinKeyDown("Zi", Yin.Zi, currentPlayer, yinListUi);
            _context.yinFreeze.Yin1Freezing = true;
        }

        if (!_context.key.value.In1 && _context.yinFreeze.Yin1Freezing)
        {
            _context.yinFreeze.Yin1Freezing = false;
        }

        if (_context.key.value.In2 && !_context.yinFreeze.Yin2Freezing)
        {
            DealYinKeyDown("Yin", Yin.Yin, currentPlayer, yinListUi);
            _context.yinFreeze.Yin2Freezing = true;
        }

        if (!_context.key.value.In2 && _context.yinFreeze.Yin2Freezing)
        {
            _context.yinFreeze.Yin2Freezing = false;
        }

        if (_context.key.value.In3 && !_context.yinFreeze.Yin3Freezing)
        {
            DealYinKeyDown("Chen", Yin.Chen, currentPlayer, yinListUi);
            _context.yinFreeze.Yin3Freezing = true;
        }

        if (!_context.key.value.In3 && _context.yinFreeze.Yin3Freezing)
        {
            _context.yinFreeze.Yin3Freezing = false;
        }

        if (_context.key.value.In4 && !_context.yinFreeze.Yin4Freezing)
        {
            DealYinKeyDown("Wu", Yin.Wu, currentPlayer, yinListUi);
            _context.yinFreeze.Yin4Freezing = true;
        }

        if (!_context.key.value.In4 && _context.yinFreeze.Yin4Freezing)
        {
            _context.yinFreeze.Yin4Freezing = false;
        }

        if (_context.key.value.In5 && !_context.yinFreeze.Yin5Freezing)
        {
            DealYinKeyDown("Shen", Yin.Shen, currentPlayer, yinListUi);
            _context.yinFreeze.Yin5Freezing = true;

        }

        if (!_context.key.value.In5 && _context.yinFreeze.Yin5Freezing)
        {
            _context.yinFreeze.Yin5Freezing = false;
        }

        if (_context.key.value.In6 && !_context.yinFreeze.Yin6Freezing)
        {
            DealYinKeyDown("Xu", Yin.Xu, currentPlayer, yinListUi);
            _context.yinFreeze.Yin6Freezing = true;

        }

        if (!_context.key.value.In6 && _context.yinFreeze.Yin6Freezing)
        {
            _context.yinFreeze.Yin6Freezing = false;
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

        var uiName = "NinjutsuYin_" + yinName + "_" + _context.currentInNumber.value;
        var yinUI = _context.CreateEntity();
        yinUI.ReplaceName(uiName);
        yinUI.ReplaceParentEntity(yinListUi);
        yinUI.ReplaceUiOpen("NinjutsuYin" + yinName);
        yinUI.ReplaceUiMoveAction(uiName, false, new Vector2(_context.currentInNumber.value * 100, 0), 0.5f * (9 - _context.currentInNumber.value) / 9);
        yinUI.ReplaceUiFadeAction(uiName, 1.0f, 0.2f);

        _context.ReplaceCurrentInNumber(_context.currentInNumber.value + 1);
    }

    private bool CheckJutsuAlreadyExist(string name, GameEntity originator)
    {
        foreach (var e in _context.GetGroup(GameMatcher.Jutsu))
        {
            if (e.name.text == name && e.originator.value == originator && !e.isDestroy)
            {
                return true;
            }
        }

        return false;
    }
}