using System.Collections.Generic;
using Entitas;
using UnityEngine;

public interface IMoveableEntity : IEntity, IAccelerationEntity, IChangingSpeedEntity, IMaxSpeedEntity, IMoveTargetEntity, IMovingEntity, ISpeedEntity, IPositionEntity { }

public partial class PlayerEntity : IMoveableEntity { }
public partial class NinjutsuEntity : IMoveableEntity { }


public class ChangeSpeedSystem : MultiReactiveSystem<IMoveableEntity, Contexts>
{
    public ChangeSpeedSystem(Contexts contexts) : base(contexts)
    {

    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.player.CreateCollector(PlayerMatcher.AllOf(PlayerMatcher.Speed, PlayerMatcher.ChangingSpeed)),
            contexts.ninjutsu.CreateCollector(NinjutsuMatcher.AllOf(NinjutsuMatcher.Speed, NinjutsuMatcher.ChangingSpeed))
        };
    }

    protected override bool Filter(IMoveableEntity entity)
    {
        return entity.isChangingSpeed;
    }

    protected override void Execute(List<IMoveableEntity> entities)
    {
        
        foreach (var e in entities)
        {
            e.ReplaceSpeed(e.speed.value + e.acceleration.value * Time.deltaTime);
            if (e.speed.value >= e.maxSpeed.value)
            {
                e.ReplaceSpeed(e.maxSpeed.value);
                e.isChangingSpeed = false;
            }
        }
    }    
}