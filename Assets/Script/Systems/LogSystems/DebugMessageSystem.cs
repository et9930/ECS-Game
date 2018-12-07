using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DebugMessageSystem : ReactiveSystem<LogEntity>
{
    public DebugMessageSystem(Contexts contexts) : base(contexts.log)
    {
    }

    protected override ICollector<LogEntity> GetTrigger(IContext<LogEntity> context)
    {
        // we only care about entities with DebugMessageComponent 
        return context.CreateCollector(LogMatcher.DebugMessage);
    }

    protected override bool Filter(LogEntity entity)
    {
        // good practice to perform a final check in case 
        // the entity has been altered in a different system.
        return entity.hasDebugMessage && !entity.isDestroy;
    }

    protected override void Execute(List<LogEntity> entities)
    {
        // this is the list of entities that meet our conditions
        foreach (var e in entities)
        {
            // we can safely access their DebugMessage component
            // then grab the string data and print it
            Debug.Log(e.debugMessage.message);
            e.isDestroy = true;
        }
    }
}