using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;

public class SwitchSceneSystem : ReactiveSystem<SceneEntity>
{
    public SwitchSceneSystem(Contexts contexts) : base(contexts.scene)
    {

    }

    protected override ICollector<SceneEntity> GetTrigger(IContext<SceneEntity> context)
    {
        return context.CreateCollector(SceneMatcher.LoadScene);
    }

    protected override bool Filter(SceneEntity entity)
    {
        return entity.hasLoadScene && !entity.isDestroy;
    }

    protected override void Execute(List<SceneEntity> entities)
    {
        foreach (var e in entities)
        {
            SceneManager.LoadScene("LoadingScene");  
            
            e.isDestroy = true;
        }
    }

    

    
}