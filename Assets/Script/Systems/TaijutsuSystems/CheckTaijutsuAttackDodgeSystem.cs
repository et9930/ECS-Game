using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class CheckTaijutsuAttackDodgeSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CheckTaijutsuAttackDodgeSystem(Contexts contexts) : base(contexts.game)
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
        // 50% + (defend speed - attack speed) * 15% - (attack taijutsu - 7) * 10%

        foreach (var e in entities)
        {
            var probability = 0.5f;
            var defenderSpeed = _context.characterBaseAttributes.dic[e.name.text].speed;
            var attackerSpeed = _context.characterBaseAttributes.dic[e.taijutsuAttackHit.hitBy.name.text].speed;
            var attackerTaijutsu = _context.characterBaseAttributes.dic[e.taijutsuAttackHit.hitBy.name.text].taijutsu;
            probability = probability + (defenderSpeed - attackerSpeed) * 0.15f - (attackerTaijutsu - 7) * 0.1f;

            if (e.taijutsuAttackHit.hitBy.position.value.X < e.position.value.X != e.toward.left)
            {
                probability -= 0.3f;
            }

            if (!Utilities.CheckSuccess(probability)) continue;

            _context.CreateEntity().ReplaceDebugMessage(e.name.text + " dodge " + e.taijutsuAttackHit.hitBy.name.text + "'s hit");
            _context.CreateEntity().ReplaceBattleValueDisplay(-1, 1, new Vector3(0, 132, 255), "闪避", e);
            e.RemoveTaijutsuAttackHit();
        }
    }
}