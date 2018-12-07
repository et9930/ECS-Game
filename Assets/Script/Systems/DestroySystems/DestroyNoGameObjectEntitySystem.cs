using System.Collections.Generic;
using Entitas;

public interface IDestroyableEntity : IEntity, IDestroyEntity { }

public partial class SceneEntity : IDestroyableEntity { }
public partial class LogEntity : IDestroyableEntity { }

public class DestroyNoGameObjectEntitySystem : MultiReactiveSystem<IDestroyableEntity, Contexts>
{
    public DestroyNoGameObjectEntitySystem(Contexts contexts) : base(contexts)
    {

    }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.scene.CreateCollector(SceneMatcher.Destroy),
            contexts.log.CreateCollector(LogMatcher.Destroy)
        };
    }

    protected override bool Filter(IDestroyableEntity entity)
    {
        return entity.isDestroy;
    }

    protected override void Execute(List<IDestroyableEntity> entities)
    {
        foreach (var e in entities)
        {
            e.Destroy();
        }
    }
      

    
}
