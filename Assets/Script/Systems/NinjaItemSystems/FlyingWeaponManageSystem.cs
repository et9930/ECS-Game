using System;
using System.Collections;
using System.Numerics;
using Entitas;

public class FlyingWeaponManageSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public FlyingWeaponManageSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetEntitiesWithTag("Weapon"))
        {
            if (!e.hasOnTheGround || (e.hasOnTheGround && e.onTheGround.value == false))
            {
                var rotation_z = (float)(Math.Atan(e.velocity.value.Y / e.velocity.value.X) * 180 / Math.PI);
                e.ReplaceRotation(new Vector3(0, 0, rotation_z));
            }
            else
            {
                if (e.rotation.value == Vector3.Zero) continue;

                e.ReplaceSprite("Image/Weapon/" + e.ninjaItemName.value + "_Ground");
                e.ReplaceAcceleration(Vector3.Zero);
                e.ReplaceVelocity(Vector3.Zero);
                e.ReplaceRotation(Vector3.Zero);
                e.RemoveBoundingBox();

//                _context.coroutineService.instance.StartCoroutine(DestroyWeapon(e, 2));
            }
        }
    }
//
//    private IEnumerator DestroyWeapon(GameEntity weapon, float time)
//    {
//        yield return _context.coroutineService.instance.WaitForSeconds(time);
//
//        weapon.isDestroy = true;
//    }
}