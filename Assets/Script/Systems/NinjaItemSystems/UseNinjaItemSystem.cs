using System;
using System.Collections.Generic;
using Entitas;

public class UseNinjaItemSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public UseNinjaItemSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UseNinjaItem);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUseNinjaItem;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var ninjaItemInfo = _context.ninjaItemAttributes.dic[e.useNinjaItem.value];
            switch (ninjaItemInfo.ninjaItemType)
            {
                case NinjaItemType.Functional:
                    for (var i = 0; i < ninjaItemInfo.ninjaItemFunctions.Count; i++)
                    {
                        switch (ninjaItemInfo.ninjaItemFunctions[i])
                        {
                            case NinjaItemFunction.Health:
                                var newHealth = e.healthCurrent.value + ninjaItemInfo.ninjaItemFunctionValues[i];
                                if (newHealth > e.healthRecoverable.value)
                                {
                                    newHealth = e.healthRecoverable.value;
                                }
                                e.ReplaceHealthCurrent(newHealth);
                                break;
                            case NinjaItemFunction.ChaKuRa:
                                var newChaKuRa = e.chaKuRaCurrent.value + ninjaItemInfo.ninjaItemFunctionValues[i];
                                if (newChaKuRa > e.chaKuRaTotal.value)
                                {
                                    newChaKuRa = e.chaKuRaTotal.value;
                                }
                                e.ReplaceChaKuRaCurrent(newChaKuRa);
                                break;
                            case NinjaItemFunction.TaiRyuKu:
                                var newTaiRyuKu = e.taiRyoKuCurrent.value + ninjaItemInfo.ninjaItemFunctionValues[i];
                                if (newTaiRyuKu > e.taiRyoKuTotal.value)
                                {
                                    newTaiRyuKu = e.taiRyoKuTotal.value;
                                }
                                e.ReplaceTaiRyoKuCurrent(newTaiRyuKu);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case NinjaItemType.Weapon:
                    e.ReplaceCurrentWeapon(e.useNinjaItem.value);
                    break;
                default:
                    break;
            }
            e.RemoveUseNinjaItem();
        }
    }
}