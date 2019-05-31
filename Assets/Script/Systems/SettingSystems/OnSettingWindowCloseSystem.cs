using System.Collections.Generic;
using Entitas;

public class OnSettingWindowCloseSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public OnSettingWindowCloseSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SettingWindowClose);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSettingWindowClose && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDestroy = true;
            var resolutionIndex = _context.sceneService.instance.GetDropdownValue("SettingWindowResolutionDropdown");
            var resolution = _context.settingValues.resolutions[resolutionIndex];
            var fullScreen = _context.sceneService.instance.GetToggleOnState("SettingWindowFullScreenToggle");
            _context.settingService.instance.SetResolution(resolution, fullScreen);
        }
    }
}