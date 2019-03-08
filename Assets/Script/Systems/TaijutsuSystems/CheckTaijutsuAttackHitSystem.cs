using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class CheckTaijutsuAttackHitSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CheckTaijutsuAttackHitSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CheckTaijutsuAttackHit);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isCheckTaijutsuAttackHit;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var attackRange = _context.characterBaseAttributes.dic[e.name.text].taijutsuAttackRange;
            if (e.hasCurrentWeapon)
            {
                if (_context.ninjaItemAttributes.dic[e.currentWeapon.value].ninjaItemWeaponTypes.Contains(NinjaItemWeaponType.HandHeld))
                {
                    attackRange += _context.ninjaItemAttributes.dic[e.currentWeapon.value].handHeldWeaponAttackPlusRadius;
                }
            }

            foreach (var targetEntity in _context.GetEntitiesWithTag("Character"))
            {
                if (e == targetEntity) continue;
                if (targetEntity.position.value.X < e.position.value.X != e.toward.left) continue;

                var distance = Vector3.Distance(e.position.value, targetEntity.position.value);

                if (distance > attackRange) continue;

                targetEntity.ReplaceTaijutsuAttackHit(e);
                _context.CreateEntity().ReplaceDebugMessage(e.name.text + " hit " + targetEntity.name.text);
            }

            e.isCheckTaijutsuAttackHit = false;
        }
    }
}