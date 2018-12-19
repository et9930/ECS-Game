using System.Collections.Generic;
using Entitas;
using UnityEngine;


public class ChangeSpeedSystem : ReactiveSystem<GameEntity>
{
    public ChangeSpeedSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {

        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Speed, GameMatcher.ChangingSpeed));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isChangingSpeed;
    }

    protected override void Execute(List<GameEntity> entities)
    {

        foreach (var e in entities)
        {
            e.ReplaceSpeed(e.speed.value + e.acceleration.value * Time.deltaTime);
            if (!(e.speed.value >= e.maxSpeed.value)) continue;
            e.ReplaceSpeed(e.maxSpeed.value);
            e.isChangingSpeed = false;
        }
    }
}