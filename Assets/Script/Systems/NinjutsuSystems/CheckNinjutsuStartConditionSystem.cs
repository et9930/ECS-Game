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
        foreach (var e in entities)
        {
            var jutsuConfig = _context.ninjutsuAttributes.dic[e.name.text];
            var originator = e.originator.value;
            var chaKuRaCoast = jutsuConfig.chaKuRaCoast;
            var taiRyuKuCoast = jutsuConfig.taiRyuKuCoast;

            if (!originator.hasId)
            {
                e.isDestroy = true;
                continue;
            }

            if (originator.chaKuRaCurrent.value >= chaKuRaCoast)
            {
                originator.ReplaceChaKuRaExpend(chaKuRaCoast);
            }
            else
            {
                originator.ReplaceChaKuRaExpend(originator.chaKuRaCurrent.value);
                taiRyuKuCoast += 1.1f * (jutsuConfig.chaKuRaCoast - originator.chaKuRaCurrent.value) / originator.chaKuRaSlewRate.value;
            }

            if (originator.taiRyoKuCurrent.value >= taiRyuKuCoast)
            {
                originator.ReplaceTaiRyoKuExpend(taiRyuKuCoast);
            }
            else
            {
                originator.ReplaceTaiRyoKuExpend(originator.taiRyoKuCurrent.value);
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
            }
        }
    }
}