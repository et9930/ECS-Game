using Entitas;

public class VelocitySystem : IExecuteSystem
{
    private readonly GameContext _context;

    public VelocitySystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.hasCurrentMapName) return;

        var currentMapConfig = _context.mapConfig.list.list[_context.currentMapName.value];

        foreach (var e in _context.GetGroup(GameMatcher.Velocity))
        {
            if (!e.hasPosition)
            {
                continue;
            }
            if (e.isMoving)
            {
                var newPosition = e.position.value;
                newPosition.X += e.velocity.value.X * _context.timeService.instance.GetDeltaTime();
                newPosition.Y += e.velocity.value.Y * _context.timeService.instance.GetDeltaTime();
                newPosition.Z += e.velocity.value.Z * _context.timeService.instance.GetDeltaTime();

                if (newPosition.X < currentMapConfig.CharacterMinX)
                    newPosition.X = currentMapConfig.CharacterMinX;

                if (newPosition.X > currentMapConfig.CharacterMaxX)
                    newPosition.X = currentMapConfig.CharacterMaxX;

                if (newPosition.Y < 0)
                    newPosition.Y = 0;
                
                
                if (newPosition.Z < currentMapConfig.CharacterMinZ)
                    newPosition.Z = currentMapConfig.CharacterMinZ;

                if (newPosition.Z > currentMapConfig.CharacterMaxZ)
                    newPosition.Z = currentMapConfig.CharacterMaxZ;

                e.ReplacePosition(newPosition);
            }
        }
    }
}