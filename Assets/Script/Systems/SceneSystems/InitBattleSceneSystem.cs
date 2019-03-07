using System.Collections.Generic;
using Entitas;

public class InitBattleSceneSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public InitBattleSceneSystem(Contexts contexts) : base(contexts.game)
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
        _context.ReplaceCurrentPlayerId(100);
        _context.ReplaceCurrentMapName("ProvingGroundMap");
        _context.CreateEntity().ReplaceLoadPlayer(100, "NamikazeMinato");
        _context.CreateEntity().ReplaceLoadPlayer(101, "UchihaMadara");
        _context.sceneService.instance.MainCameraPosition =
            _context.mapConfig.list.list[_context.currentMapName.value].CameraPosition[0];
    }
}