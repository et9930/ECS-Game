using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;

public class SwitchSceneSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public SwitchSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
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
            _context.sceneService.instance.SwitchScene(e.loadScene.name, new string[2], _context);
            e.isDestroy = true;
        }
    }

    

    
}