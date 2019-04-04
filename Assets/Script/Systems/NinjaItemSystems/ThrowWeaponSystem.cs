using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class ThrowWeaponSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public ThrowWeaponSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceThrowWeaponNumber(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TryThrowWeapon);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTryThrowWeapon;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasCurrentWeapon)
            {
                var weaponConfig = _context.ninjaItemAttributes.dic[e.currentWeapon.value];
                if (weaponConfig.ninjaItemWeaponTypes.Contains(NinjaItemWeaponType.Throwing))
                {
                    var weapon = _context.CreateEntity();
                    weapon.ReplaceName(e.currentWeapon.value + _context.throwWeaponNumber.value);
                    weapon.ReplaceNinjaItemName(e.currentWeapon.value);
                    weapon.ReplaceTag("Weapon");
                    weapon.ReplaceBoundingBox(0,0,0,0,0,0);
                    weapon.ReplaceSprite("Image/Weapon/" + e.currentWeapon.value);
                    weapon.ReplaceId((400 + _context.throwWeaponNumber.value).ToString());
//                    weapon.ReplaceVelocity(new Vector3(, 0, 0));
                    weapon.ReplaceVelocity(new Vector3(e.toward.left ? -1 : 1, 0, 0) * weaponConfig.throwingWeaponFlaySpeed);
                    weapon.ReplaceRotation(Vector3.Zero);
                    var position = e.position.value;
                    position.Y = 1.2f;
                    weapon.ReplacePosition(position);
                    weapon.ReplaceHierarchy(e.hierarchy.value);
                    weapon.ReplaceToward(e.toward.left);
                    weapon.ReplaceScale(e.scale.value);
                    weapon.isQuickActionObject = true;

                    if (weaponConfig.ninjaItemSpecialEffects.Contains(NinjaItemSpecialEffect.MinatoHiRaiShinMaKinGu))
                    {
                        weapon.isMinatoHiRaiShinMaKinGu = true;
                    }

                    _context.ReplaceThrowWeaponNumber(_context.throwWeaponNumber.value + 1);
                    _context.coroutineService.instance.StartCoroutine(StopFlying(weapon, weaponConfig.throwingWeaponMaxFlyTime));
                }
                else if(weaponConfig.ninjaItemWeaponTypes.Contains(NinjaItemWeaponType.Placing))
                {
                    
                }
            }

            e.isTryThrowWeapon = false;
        }
    }

    private IEnumerator StopFlying(GameEntity weapon, float time)
    {
        yield return _context.coroutineService.instance.WaitForSeconds(time);
        weapon.ReplaceAcceleration(new Vector3(0, -1, 0));
    }
}