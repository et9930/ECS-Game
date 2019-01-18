using System.Numerics;
using Entitas;

public class MoveMainCameraSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public MoveMainCameraSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;

        var currentMapConfig = _context.mapConfig.list.list[_context.currentMapName.value];
        foreach (var e in _context.GetGroup(GameMatcher.PlayerId))
        {
            if (e.playerId.value == _context.currentPlayerId.value)
            {
                var tempPosition = new Vector3(e.position.value.X, 0, -10);

                if (e.position.value.X < currentMapConfig.CameraMinX)
                    tempPosition.X = currentMapConfig.CameraMinX;

                if (e.position.value.X > currentMapConfig.CameraMaxX)
                    tempPosition.X = currentMapConfig.CameraMaxX;

                _context.sceneService.instance.MoveMainCamera(tempPosition);
            }
        }
    }
}