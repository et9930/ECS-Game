using System.Collections.Generic;
using Entitas;

public class CheckTaijutsuAttackDefendSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CheckTaijutsuAttackDefendSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TaijutsuAttackHit);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTaijutsuAttackHit;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        // 80% - (f(attack taijutsu) - f(defend taijutsu)) * 2% - attack power > defend power ? (attack power - defend power) * 10% : 0% + defend has weapon ? 5% : 0%
        
        foreach (var e in entities)
        {
            var probability = 0.8f;
            var attackerTaijutsu = _context.characterBaseAttributes.dic[e.taijutsuAttackHit.hitBy.name.text].taijutsu;
            var attackerPower = _context.characterBaseAttributes.dic[e.taijutsuAttackHit.hitBy.name.text].power;
            var defenderTaijutsu = _context.characterBaseAttributes.dic[e.name.text].taijutsu;
            var defenderPower = _context.characterBaseAttributes.dic[e.name.text].power;

            probability -= (TaijutsuFunction(attackerTaijutsu) - TaijutsuFunction(defenderTaijutsu)) * 0.02f;
            if (attackerPower > defenderPower)
            {
                probability -= (attackerPower - defenderPower) * 0.1f;
            }

            if (e.hasCurrentWeapon)
            {
                probability += 0.05f;
            }

            if (e.taijutsuAttackHit.hitBy.position.value.X < e.position.value.X != e.toward.left)
            {
                probability -= 0.5f;
            }

            if (!Utilities.CheckSuccess(probability)) continue;

            _context.CreateEntity().ReplaceDebugMessage(e.name.text + " defend " + e.taijutsuAttackHit.hitBy.name.text + "'s hit");
            e.isDefendSuccess = true;
        }
    }

    private float TaijutsuFunction(int taijutsu)
    {
        return -0.5f * taijutsu * taijutsu + 11.5f * taijutsu;
    }
}