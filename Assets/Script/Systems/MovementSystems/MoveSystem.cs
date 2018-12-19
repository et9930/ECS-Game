using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveSystem : ReactiveSystem<GameEntity>
{
    public MoveSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Moving));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMoving;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var deltaX = e.moveTarget.value.x - e.position.value.x;
            var deltaY = e.moveTarget.value.y - e.position.value.y;
            var delta = Mathf.Sqrt(Mathf.Pow(deltaX, 2) + Mathf.Pow(deltaY, 2));

            if (delta <= e.speed.value * Time.deltaTime)
            {
                e.ReplaceSpeed(0.0f);
                e.ReplacePosition(e.moveTarget.value);
                //e.RemoveMoveTarget();
                e.isMoving = false;
                e.isChangingSpeed = false;
            }
            else
            {
                var deltaSpeedX = e.speed.value * deltaX / delta;
                var deltaSpeedY = e.speed.value * deltaY / delta;
                var newPosition = e.position.value + Time.deltaTime * new Vector2(deltaSpeedX, deltaSpeedY);
                e.ReplacePosition(newPosition);
            }        
        }
    }
}