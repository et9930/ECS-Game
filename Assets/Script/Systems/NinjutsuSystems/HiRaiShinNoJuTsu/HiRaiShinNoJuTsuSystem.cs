using System.Collections.Generic;
using Entitas;

public class HiRaiShinNoJuTsuSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public HiRaiShinNoJuTsuSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Jutsu, GameMatcher.StartConditionConfirm));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJutsu && entity.name.text == "HiRaiShinNoJuTsu" && entity.isStartConditionConfirm;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var targetPosition = e.jutsuTarget.value.position.value;
            targetPosition.X = Utilities.RandomFloat(targetPosition.X - 0.5f, targetPosition.X + 0.5f);
            targetPosition.Z = Utilities.RandomFloat(targetPosition.Z - 0.5f, targetPosition.Z + 0.5f);
            e.originator.value.ReplacePosition(targetPosition);
            e.isDestroy = true;
            var cameraPosition = _context.sceneService.instance.MainCameraPosition;
            cameraPosition.X = targetPosition.X;
            _context.sceneService.instance.MainCameraPosition = cameraPosition;
        }
    }
}