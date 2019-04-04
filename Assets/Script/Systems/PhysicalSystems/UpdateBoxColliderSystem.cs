using System.Numerics;
using Entitas;

public class UpdateBoxColliderSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public UpdateBoxColliderSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        foreach (var e in _context.GetGroup(GameMatcher.QuickActionObject))
        {
            if (!e.isView) continue;

            var size = _context.viewService.instance.GetViewSize(e.name.text);
            var pivot = _context.viewService.instance.GetViewPivot(e.name.text);
            var offset = new Vector2((e.toward.left ? -1.0f : 1.0f) * (size.X * (0.5f - pivot.X)), size.Y * (0.5f - pivot.Y));
            _context.physicsService.instance.UpdateBoxCollision(e, size, offset);
        }
    }
}