using System;
using System.Collections.Generic;
using Entitas;

public class OnSettingWindowOpenSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public OnSettingWindowOpenSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SettingWindowOpen);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isSettingWindowOpen && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDestroy = true;
            var resolutions = _context.settingService.instance.GetSupportedResolutions();
            var currentResolution = _context.settingService.instance.GetCurrentResolution();
            var isFullScreen = _context.settingService.instance.isFullScreen;

            _context.ReplaceSettingValues(resolutions, currentResolution, isFullScreen);
        }
    }
}