using System.Collections.Generic;
using Entitas;

public class InitMainSceneSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public InitMainSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CurrentScene);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCurrentScene && entity.currentScene.name == "BattleScene";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }
}