using System;
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
        if (_context.currentScene.name != "BattleScene") return;

        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        var perceptionLevel = _context.characterBaseAttributes.dic[currentPlayer.name.text].perceptionLevel;
        foreach (var e in _context.GetEntitiesWithTag("Character"))
        {
            if (e == currentPlayer) continue;

            var antiPerceptionLevel = e.antiPerceptionLevel.value;
            var distance = Vector3.Distance(currentPlayer.position.value, e.position.value);

            var finalLevel = perceptionLevel - antiPerceptionLevel - (int)distance / 15;

            var eScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(e.position.value);
            if (eScreenPosition.X >= 0 && eScreenPosition.X <= 1920 && eScreenPosition.Y >= 0 && eScreenPosition.Y <= 1080)
            {
                finalLevel = -1;
            }

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
            else if (finalLevel >= 3 && finalLevel < 5)
            {
                if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionAccurate.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionAccurate.dic.Remove(e.name.text);
                }
                distance = -1;
                if (e.position.value.X < currentPlayer.position.value.X)
                {
                    if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                    {
                        _context.perceptionPositionExist.dic[e.name.text].ReplacePerceptionPositionExistItem("Unknown", (int)distance, true);
                    }
                    else
                    {
                        GameEntity listEntity = null;
                        foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                        {
                            if (ui.name.text != "PerceptionPositionExistLeftList") continue;
                            listEntity = ui;
                            break;
                        }

                        if (listEntity == null) continue;

                        var itemEntity = _context.CreateEntity();
                        itemEntity.ReplaceName("PerceptionPositionExistItem");
                        itemEntity.ReplaceParentEntity(listEntity);
                        itemEntity.ReplaceUiOpen("PerceptionPositionExistItem");
                        itemEntity.ReplacePerceptionPositionExistItem("Unknown", (int)distance, true);
                        _context.perceptionPositionExist.dic[e.name.text] = itemEntity;
                    }
                }
                else
                {
                    if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                    {
                        _context.perceptionPositionExist.dic[e.name.text].ReplacePerceptionPositionExistItem("Unknown", (int)distance, false);
                    }
                    else
                    {
                        GameEntity listEntity = null;
                        foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                        {
                            if (ui.name.text != "PerceptionPositionExistRightList") continue;
                            listEntity = ui;
                            break;
                        }

                        if (listEntity == null) continue;

                        var itemEntity = _context.CreateEntity();
                        itemEntity.ReplaceName("PerceptionPositionExistItem");
                        itemEntity.ReplaceParentEntity(listEntity);
                        itemEntity.ReplaceUiOpen("PerceptionPositionExistItem");
                        itemEntity.ReplacePerceptionPositionExistItem("Unknown", (int)distance, false);
                        _context.perceptionPositionExist.dic[e.name.text] = itemEntity;
                    }
                }
            }
            else if(finalLevel >= 5 && finalLevel < 10)
            {
                if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionAccurate.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionAccurate.dic.Remove(e.name.text);
                }
                distance = (int)distance / 10 * 10;
                if (e.position.value.X < currentPlayer.position.value.X)
                {
                    if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                    {
                        _context.perceptionPositionExist.dic[e.name.text].ReplacePerceptionPositionExistItem(e.name.text, (int)distance, true);
                    }
                    else
                    {
                        GameEntity listEntity = null;
                        foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                        {
                            if (ui.name.text != "PerceptionPositionExistLeftList") continue;
                            listEntity = ui;
                            break;
                        }

                        if (listEntity == null) continue;

                        var itemEntity = _context.CreateEntity();
                        itemEntity.ReplaceName("PerceptionPositionExistItem");
                        itemEntity.ReplaceParentEntity(listEntity);
                        itemEntity.ReplaceUiOpen("PerceptionPositionExistItem");
                        itemEntity.ReplacePerceptionPositionExistItem(e.name.text, (int)distance, true);
                        _context.perceptionPositionExist.dic[e.name.text] = itemEntity;
                    }
                }
                else
                {
                    if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                    {
                        _context.perceptionPositionExist.dic[e.name.text].ReplacePerceptionPositionExistItem(e.name.text, (int)distance, false);
                    }
                    else
                    {
                        GameEntity listEntity = null;
                        foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                        {
                            if (ui.name.text != "PerceptionPositionExistRightList") continue;
                            listEntity = ui;
                            break;
                        }

                        if (listEntity == null) continue;

                        var itemEntity = _context.CreateEntity();
                        itemEntity.ReplaceName("PerceptionPositionExistItem");
                        itemEntity.ReplaceParentEntity(listEntity);
                        itemEntity.ReplaceUiOpen("PerceptionPositionExistItem");
                        itemEntity.ReplacePerceptionPositionExistItem(e.name.text, (int)distance, false);
                        _context.perceptionPositionExist.dic[e.name.text] = itemEntity;
                    }
                }
            }
            else // >= 10
            {
                if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
                {
                    _context.perceptionPositionExist.dic[e.name.text].isUiClose = true;
                    _context.perceptionPositionExist.dic.Remove(e.name.text);
                }
                if (e.position.value.X < currentPlayer.position.value.X)
                {
                    if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                    {
                        _context.perceptionPositionAccurate.dic[e.name.text].ReplacePerceptionPositionAccurateItem(e.name.text, true, eScreenPosition.Y, (int)distance);
                    }
                    else
                    {
                        var itemEntity = _context.CreateEntity();
                        itemEntity.ReplaceName("PerceptionPositionAccurateItemLeft");
                        itemEntity.ReplaceUiOpen("PerceptionPositionAccurateItemLeft");
                        itemEntity.ReplacePerceptionPositionAccurateItem(e.name.text, true, eScreenPosition.Y, (int)distance);
                        _context.perceptionPositionAccurate.dic[e.name.text] = itemEntity;
                    }
                }
                else
                {
                    if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
                    {
                        _context.perceptionPositionAccurate.dic[e.name.text].ReplacePerceptionPositionAccurateItem(e.name.text, false, eScreenPosition.Y, (int)distance);
                    }
                    else
                    {
                        var itemEntity = _context.CreateEntity();
                        itemEntity.ReplaceName("PerceptionPositionAccurateItemRight");
                        itemEntity.ReplaceUiOpen("PerceptionPositionAccurateItemRight");
                        itemEntity.ReplacePerceptionPositionAccurateItem(e.name.text, false, eScreenPosition.Y, (int)distance);
                        _context.perceptionPositionAccurate.dic[e.name.text] = itemEntity;
                    }
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
                if (ui.name.text != "PerceptionPositionExistLeft") continue;
                ui.ReplaceActive(leftNum > 0);
                break;
            }

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "PerceptionPositionExistRight") continue;
                ui.ReplaceActive(rightNum > 0);
                break;
            }
        }
    }
}
