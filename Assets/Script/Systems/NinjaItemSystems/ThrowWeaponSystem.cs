using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class ThrowWeaponSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ThrowWeaponSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ThrowWeaponControl);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasThrowWeaponControl && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var weaponConfig = _context.ninjaItemAttributes.dic[e.throwWeaponControl.value.weaponName];
            if (weaponConfig.ninjaItemWeaponTypes.Contains(NinjaItemWeaponType.Throwing))
            {
                var weapon = _context.CreateEntity();
                weapon.ReplaceName(e.throwWeaponControl.value.weaponName + e.throwWeaponControl.value.weaponId);
                weapon.ReplaceNinjaItemName(e.throwWeaponControl.value.weaponName);
                weapon.ReplaceTag("Weapon");
                weapon.ReplaceBoundingBox(0,0,0,0,0,0);
                weapon.ReplaceSprite("Image/Weapon/" + e.throwWeaponControl.value.weaponName);
                weapon.ReplaceId(e.throwWeaponControl.value.weaponId);
                weapon.ReplaceVelocity(new Vector3(e.throwWeaponControl.value.left ? -1 : 1, 0, 0) * weaponConfig.throwingWeaponFlaySpeed);
                weapon.ReplaceRotation(Vector3.Zero);
                var position = e.throwWeaponControl.value.position;
                position.Y = 1.2f;
                weapon.ReplacePosition(position);
                weapon.ReplaceHierarchy(e.throwWeaponControl.value.hierarchy);
                weapon.ReplaceToward(e.throwWeaponControl.value.left);
                weapon.ReplaceScale(Vector2.One);
                weapon.isQuickActionObject = true;

                if (weaponConfig.ninjaItemSpecialEffects.Contains(NinjaItemSpecialEffect.MinatoHiRaiShinMaKinGu))
                {
                    weapon.isMinatoHiRaiShinMaKinGu = true;
                }

                _context.coroutineService.instance.StartCoroutine(StopFlying(weapon, weaponConfig.throwingWeaponMaxFlyTime));
            }
            else if(weaponConfig.ninjaItemWeaponTypes.Contains(NinjaItemWeaponType.Placing))
            {
                
            }

            e.isDestroy = true;
        }
    }

    private IEnumerator StopFlying(GameEntity weapon, float time)
    {
        yield return _context.coroutineService.instance.WaitForSeconds(time);
        weapon.ReplaceAcceleration(new Vector3(0, -1, 0));
    }
}