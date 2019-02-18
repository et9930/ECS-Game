using System;
using Entitas;

public class UiFollowSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public UiFollowSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.ParentEntity))
        {
            if (!e.hasUiRootId) continue;

            var parentPosition = e.parentEntity.value.position.value;
            var parentScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(parentPosition);
            parentScreenPosition.X -= _context.viewService.instance.ScreenSize.X / 2;
            parentScreenPosition.Y -= _context.viewService.instance.ScreenSize.Y / 2;
            _context.sceneService.instance.SetUIPosition(e.name.text, parentScreenPosition);
        }
    }
}