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
        _context.ReplaceCurrentMapName("ProvingGroundMap");

        var matchData = _context.currentMatchData.value;
        Utilities.SetRandomSeed(matchData.matchRandomSeed);

        foreach (var player in matchData.matchPlayers)
        {
            _context.CreateEntity().ReplaceLoadPlayer(
                player.userId,
                player.ninjaName,
                _context.mapConfig.list[_context.currentMapName.value].CharacterInPosition[player.position],
                player.team == 2,
                player.team
            );

            if (player.userId == _context.currentPlayerId.value)
            {
                _context.sceneService.instance.MainCameraPosition = _context.mapConfig.list[_context.currentMapName.value].CameraPosition[player.team - 1];
            }
        }
    }
}