using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class PerceptionPositionSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;

    public PerceptionPositionSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplacePerceptionPositionExist(new Dictionary<string, GameEntity>());
        _context.ReplacePerceptionPositionAccurate(new Dictionary<string, GameEntity>());
    }

    public void Execute()
    {
        if (_context.hasBattleOver) return;

        if (_context.currentScene.name != "BattleScene") return;
        if (_context.GetGroup(GameMatcher.LoadPlayer).count > 0) return;


        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null) return;

        foreach (var e in _context.GetEntitiesWithTag("Character"))
        {
            if (e == currentPlayer) continue;

            var distance = Vector3.Distance(currentPlayer.position.value, e.position.value);
            var finalLevel = e.finalPerceptionLevel.value;

            var eScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(e.position.value);
            if (eScreenPosition.X >= 0 && eScreenPosition.X <= _context.viewService.instance.ScreenSize.X && eScreenPosition.Y >= 0 && eScreenPosition.Y <= _context.viewService.instance.ScreenSize.Y)
            {
                finalLevel = -1;
            }

            GameEntity listEntity = null;
            var left = e.position.value.X < currentPlayer.position.value.X;
            var listName = left ? "PerceptionPositionExistLeftList" : "PerceptionPositionExistRightList";
            var accurateName = left ? "PerceptionPositionAccurateItemLeft" : "PerceptionPositionAccurateItemRight";
            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (!ui.hasName) continue;

                if (ui.name.text != listName) continue;
                listEntity = ui;
                break;
            }
            if (listEntity == null) continue;

            if (finalLevel < 3)
            {
                if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionExist.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionExist.dic.Remove(e.name.text);
                }

                if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionAccurate.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionAccurate.dic.Remove(e.name.text);
                }
            }
            else if(finalLevel >= 10)
            {
                if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionExist.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionExist.dic.Remove(e.name.text);
                }

                if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionAccurate.dic[e.name.text].ReplacePerceptionPositionAccurateItem(e.name.text, left, eScreenPosition.Y, (int) distance);
                }
                else
                {
                    var itemEntity = _context.CreateEntity();
                    itemEntity.ReplaceName(accurateName + "_" + e.name.text);
                    itemEntity.ReplaceUiOpen(accurateName);
                    itemEntity.ReplacePerceptionPositionAccurateItem(e.name.text, left, eScreenPosition.Y, (int) distance);
                    itemEntity.ReplacePerceptionTarget(e);
                    itemEntity.isQuickActionObject = true;
                    _context.perceptionPositionAccurate.dic[e.name.text] = itemEntity;
                }
            }
            else
            {
                string name;
                bool canQuickAction;
                if (finalLevel >= 5)
                {
                    distance = (int)distance / 10 * 10;
                    name = e.name.text;
                    canQuickAction = true;
                }
                else
                {
                    distance = -1;
                    name = "Unknown";
                    canQuickAction = false;
                }

                if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionAccurate.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionAccurate.dic.Remove(e.name.text);
                }

                if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionExist.dic[e.name.text].ReplacePerceptionPositionExistItem(name, (int)distance, left);
                    _context.perceptionPositionExist.dic[e.name.text].isQuickActionObject = canQuickAction;
                }
                else
                {
                    var itemEntity = _context.CreateEntity();
                    itemEntity.ReplaceName("PerceptionPositionExistItem_" + e.name.text);
                    itemEntity.ReplaceParentEntity(listEntity);
                    itemEntity.ReplaceUiOpen("PerceptionPositionExistItem");
                    itemEntity.ReplacePerceptionPositionExistItem(name, (int)distance, left);
                    itemEntity.ReplacePerceptionTarget(e);
                    itemEntity.isQuickActionObject = canQuickAction;
                    
                    _context.perceptionPositionExist.dic[e.name.text] = itemEntity;
                }
            }

            var leftNum = 0;
            var rightNum = 0;
            foreach (var keyValue in _context.perceptionPositionExist.dic)
            {
                if (keyValue.Value.perceptionPositionExistItem.left)
                {
                    leftNum++;
                }
                else
                {
                    rightNum++;
                }
            }

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (!ui.hasName) continue;
                if (ui.name.text != "PerceptionPositionExistLeft") continue;
                ui.ReplaceActive(leftNum > 0);
                break;
            }

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (!ui.hasName) continue;
                if (ui.name.text != "PerceptionPositionExistRight") continue;
                ui.ReplaceActive(rightNum > 0);
                break;
            }
        }
    }
}
