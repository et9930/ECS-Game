using System.Collections.Generic;
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

        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        var lastPosition = _context.sceneService.instance.MainCameraPosition;

        var tempPosition = new Vector3(currentPlayer.position.value.X, 0, -10);
        tempPosition.X += currentPlayer.toward.left ? -6 : 6;

        if (tempPosition.X > lastPosition.X)
        {
            lastPosition.X += 10 * _context.timeService.instance.GetDeltaTime();
            if (lastPosition.X > tempPosition.X)
            {
                lastPosition.X = tempPosition.X;
            }
        }
        else if (tempPosition.X < lastPosition.X)
        {
            lastPosition.X -= 10 * _context.timeService.instance.GetDeltaTime();
            if (lastPosition.X < tempPosition.X)
            {
                lastPosition.X = tempPosition.X;
            }
        }
        
        if (lastPosition.X < currentMapConfig.CameraMinX)
            lastPosition.X = currentMapConfig.CameraMinX;

        if (lastPosition.X > currentMapConfig.CameraMaxX)
            lastPosition.X = currentMapConfig.CameraMaxX;

        _context.sceneService.instance.MainCameraPosition = lastPosition;
    }
}