using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;

public class SwitchSceneSystem : ReactiveSystem<GameEntity>
{
    public SwitchSceneSystem(Contexts contexts) : base(contexts.game)
    {

    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadScene);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadScene && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            SceneManager.LoadScene("LoadingScene");  
            
            e.isDestroy = true;
        }
    }

    

    
}