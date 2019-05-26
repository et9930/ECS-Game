using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class CalculateTaijutsuAttackDamageSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CalculateTaijutsuAttackDamageSystem(Contexts contexts) : base(contexts.game)
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
        foreach (var e in entities)
        {
            var baseDamage = 7.0f;
            var attackerTaijutsu = _context.characterBaseAttributes.dic[e.taijutsuAttackHit.hitBy.name.text].taijutsu;
            var attackerPower = _context.characterBaseAttributes.dic[e.taijutsuAttackHit.hitBy.name.text].power;
            var defenderTaijutsu = _context.characterBaseAttributes.dic[e.name.text].taijutsu;
            var defenderPower = _context.characterBaseAttributes.dic[e.name.text].power;
            var defendSuccess = e.isDefendSuccess;
            baseDamage *= 1.0f + (float) Math.Pow(attackerTaijutsu - defenderTaijutsu, 2) * 0.05f + (attackerPower - defenderPower) * 0.07f;

            if (e.isDefendSuccess)
            {
                baseDamage *= 0.3f;
                e.isDefendSuccess = false;
            }

            if (e.taijutsuAttackHit.hitBy.position.value.X < e.position.value.X != e.toward.left)
            {
                baseDamage *= 1.5f;
            }

            if (defendSuccess)
            {
                _context.CreateEntity().ReplaceBattleValueDisplay((int)baseDamage, 2, new Vector3(100, 100, 100), "防御成功", e);
            }
            else
            {
                _context.CreateEntity().ReplaceBattleValueDisplay((int)baseDamage, 2, new Vector3(200, 200, 200), "防御失败", e);
            }

            e.ReplaceHealthReduce(baseDamage);
            e.RemoveTaijutsuAttackHit();
        }
    }
}