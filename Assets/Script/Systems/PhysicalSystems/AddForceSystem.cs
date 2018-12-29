using System.Collections;
using System.Collections.Generic;
using Entitas;

public class AddForceSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddForceSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AddForce);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAddForce && entity.hasMass;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.coroutineService.instance.StartCoroutine(AddForceToEntity(e));
        }
    }

    private IEnumerator AddForceToEntity(GameEntity e)
    {
        var addForceAcceleration = e.acceleration.value;
        addForceAcceleration.X += e.addForce.ForceValue.X / e.mass.value;
        addForceAcceleration.Y += e.addForce.ForceValue.Y / e.mass.value;
        e.ReplaceAcceleration(addForceAcceleration);

        yield return _context.coroutineService.instance.WaitForSeconds(e.addForce.DurationTime);

        var removeForceAcceleration = e.acceleration.value;
        removeForceAcceleration.X -= e.addForce.ForceValue.X / e.mass.value;
        removeForceAcceleration.Y -= e.addForce.ForceValue.Y / e.mass.value;
        e.ReplaceAcceleration(removeForceAcceleration);

        e.RemoveAddForce();
    }
}