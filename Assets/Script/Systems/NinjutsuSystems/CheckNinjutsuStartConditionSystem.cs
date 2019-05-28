using System.Collections.Generic;
using Entitas;

public class CheckNinjutsuStartConditionSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CheckNinjutsuStartConditionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Jutsu);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJutsu && !entity.isStartConditionConfirm && entity.hasName && entity.hasOriginator && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            var jutsuConfig = _context.ninjutsuAttributes.dic[e.name.text];
            var originator = e.originator.value;
            var chaKuRaCoast = jutsuConfig.chaKuRaCoast;
            var taiRyuKuCoast = jutsuConfig.taiRyuKuCoast;

            if (originator.isDead)
            {
                continue;
            }
            if (!originator.hasId)
            {
                e.isDestroy = true;
                continue;
            }

            if (originator.chaKuRaCurrent.value >= chaKuRaCoast)
            {
//                originator.ReplaceChaKuRaExpend(chaKuRaCoast);
                var newChaKuRaExpend = new MatchDataChaKuRaExpendControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = originator.id.value,
                    chaKuRaExpend = chaKuRaCoast
                };
                _context.CreateEntity().ReplaceSendMatchData(1007, Utilities.ToJson(newChaKuRaExpend));
            }
            else
            {
//                originator.ReplaceChaKuRaExpend(originator.chaKuRaCurrent.value);
                var newChaKuRaExpend = new MatchDataChaKuRaExpendControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = originator.id.value,
                    chaKuRaExpend = originator.chaKuRaCurrent.value
                };
                _context.CreateEntity().ReplaceSendMatchData(1007, Utilities.ToJson(newChaKuRaExpend));

                taiRyuKuCoast += 1.1f * (jutsuConfig.chaKuRaCoast - originator.chaKuRaCurrent.value) / originator.chaKuRaSlewRate.value;
            }

            if (originator.taiRyoKuCurrent.value >= taiRyuKuCoast)
            {
//                originator.ReplaceTaiRyoKuExpend(taiRyuKuCoast);
                var newTaiRyoKuExpend = new MatchDataTaiRyuKuExpendControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = originator.id.value,
                    taiRyuKuExpend = taiRyuKuCoast
                };
                _context.CreateEntity().ReplaceSendMatchData(1008, Utilities.ToJson(newTaiRyoKuExpend));

            }
            else
            {
//                originator.ReplaceTaiRyoKuExpend(originator.taiRyoKuCurrent.value);
                var newTaiRyoKuExpend = new MatchDataTaiRyuKuExpendControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = originator.id.value,
                    taiRyuKuExpend = originator.taiRyoKuCurrent.value
                };
                _context.CreateEntity().ReplaceSendMatchData(1008, Utilities.ToJson(newTaiRyoKuExpend));

                e.isDestroy = true;
            }

            foreach (var beforeJutsu in _context.GetGroup(GameMatcher.BeforeJutsuTarget))
            {
                if (beforeJutsu.name.text == e.name.text)
                {
                    e.ReplaceJutsuTarget(beforeJutsu.jutsuTarget.value);
                }

                beforeJutsu.isDestroy = true;
            }

            if (!jutsuConfig.needSelectTarget || jutsuConfig.needSelectTarget && e.hasJutsuTarget)
            {
                e.isStartConditionConfirm = true;
                var newJutsuControl = new MatchDataJutsuControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    originatorId = e.originator.value.id.value,
                    jutsuName = e.name.text,
                    needTarget = jutsuConfig.needSelectTarget
                };
                if (jutsuConfig.needSelectTarget)
                {
                    newJutsuControl.targetId = e.jutsuTarget.value.id.value;
                }
                _context.CreateEntity().ReplaceSendMatchData(1011, Utilities.ToJson(newJutsuControl));
                e.isDestroy = true;
            }
        }
    }
}