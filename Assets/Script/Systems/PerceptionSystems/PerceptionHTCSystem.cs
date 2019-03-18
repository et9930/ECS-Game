using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class PerceptionHTCSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;

    public PerceptionHTCSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplacePerceptionHTC(new Dictionary<string, GameEntity>());
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (_context.GetGroup(GameMatcher.LoadPlayer).count > 0) return;


        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        foreach (var e in _context.GetEntitiesWithTag("Character"))
        {
            if (e == currentPlayer) continue;

            var finalLevel = e.finalPerceptionLevel.value;
            var hp = -1.0f;
            var tp = -1.0f;
            var cp = -1.0f;

            // H
            if (finalLevel >= 4 && finalLevel < 6)
                hp = GetPercentValue(e.healthCurrent.value, e.healthTotal.value, 3);
            else if (finalLevel >= 6 && finalLevel < 9)
                hp = GetPercentValue(e.healthCurrent.value, e.healthTotal.value, 6);
            else if (finalLevel >= 9 && finalLevel < 11)
                hp = GetPercentValue(e.healthCurrent.value, e.healthTotal.value, 10);
            else if (finalLevel >= 11)
                hp = GetPercentValue(e.healthCurrent.value, e.healthTotal.value, 0);
            // T
            if (finalLevel >= 4 && finalLevel < 8)
                tp = GetPercentValue(e.taiRyoKuCurrent.value, e.taiRyoKuTotal.value, 3);
            else if(finalLevel >= 8 && finalLevel < 11)
                tp = GetPercentValue(e.taiRyoKuCurrent.value, e.taiRyoKuTotal.value, 6);
            else if(finalLevel >= 11 && finalLevel < 14)
                tp = GetPercentValue(e.taiRyoKuCurrent.value, e.taiRyoKuTotal.value, 10);
            else if (finalLevel >= 14)
                tp = GetPercentValue(e.taiRyoKuCurrent.value, e.taiRyoKuTotal.value, 0);
            // C
            if (finalLevel >= 5 && finalLevel < 7)
                cp = GetPercentValue(e.chaKuRaCurrent.value, e.chaKuRaTotal.value, 3);
            else if (finalLevel >= 7 && finalLevel < 10)
                cp = GetPercentValue(e.chaKuRaCurrent.value, e.chaKuRaTotal.value, 6);
            else if (finalLevel >= 10 && finalLevel < 13)
                cp = GetPercentValue(e.chaKuRaCurrent.value, e.chaKuRaTotal.value, 10);
            else if (finalLevel >= 13)
                cp = GetPercentValue(e.chaKuRaCurrent.value, e.chaKuRaTotal.value, 0);

            GameEntity itemEntity;
            if (_context.perceptionHTC.dic.ContainsKey(e.name.text))
            {
                itemEntity = _context.perceptionHTC.dic[e.name.text];
                _context.perceptionHTC.dic[e.name.text].ReplacePerceptionHTCItem(hp, tp, cp);
            }
            else
            {
                itemEntity = _context.CreateEntity();
                itemEntity.ReplaceName("PerceptionHTCItem" + e.name.text);
                itemEntity.ReplaceUiOpen("PerceptionHTCItem");
                itemEntity.ReplacePerceptionHTCItem(hp, tp, cp);
                itemEntity.ReplacePerceptionTarget(e);
                _context.perceptionHTC.dic[e.name.text] = itemEntity;
                continue;
            }

            if (_context.perceptionPositionExist.dic.ContainsKey(e.name.text))
            {
                itemEntity.ReplaceParentEntity(_context.perceptionPositionExist.dic[e.name.text]);
                itemEntity.ReplaceUiExcursion(Vector2.Zero);
            }
            else if (_context.perceptionPositionAccurate.dic.ContainsKey(e.name.text))
            {
                itemEntity.ReplaceParentEntity(_context.perceptionPositionAccurate.dic[e.name.text]);
                itemEntity.ReplaceUiExcursion(new Vector2(itemEntity.parentEntity.value.perceptionPositionAccurateItem.left ? 15 : -15, 40));
            }
            else
            {
                itemEntity.ReplaceParentEntity(e);
                if (!e.isView)
                {
                    itemEntity.RemoveParentEntity();
                    continue;
                }

                itemEntity.ReplaceUiExcursion(new Vector2(0, 180));
            }
        }
    }

    private float GetPercentValue(float current, float total, int sectionNum)
    {
        var percentValue = current / total;
        if (sectionNum > 0)
        {
            var single = 1.0f / sectionNum;

            for (var i = 1; i <= sectionNum; i++)
            {
                if (i * single >= percentValue)
                {
                    return i * single;
                }
            }
        }
        return percentValue;
    }
}