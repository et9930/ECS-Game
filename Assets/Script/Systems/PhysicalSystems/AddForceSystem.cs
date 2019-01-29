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
        _context.CreateEntity().ReplaceDebugMessage(e.name.text + " add force " + e.addForce.ForceValue);
        var forceValue = e.addForce.ForceValue;
        var durationTime = e.addForce.DurationTime;
        var addForceAcceleration = e.acceleration.value;
        addForceAcceleration.X += forceValue.X / e.mass.value;
        addForceAcceleration.Y += forceValue.Y / e.mass.value;
        addForceAcceleration.Z += forceValue.Z / e.mass.value;
        e.ReplaceAcceleration(addForceAcceleration);
        e.RemoveAddForce();

        yield return _context.coroutineService.instance.WaitForSeconds(durationTime);

        _context.CreateEntity().ReplaceDebugMessage(e.name.text + " remove force " + forceValue);
        var removeForceAcceleration = e.acceleration.value;
        removeForceAcceleration.X -= forceValue.X / e.mass.value;
        removeForceAcceleration.Y -= forceValue.Y / e.mass.value;
        removeForceAcceleration.Z -= forceValue.Z / e.mass.value;
        e.ReplaceAcceleration(removeForceAcceleration);

        
    }
}