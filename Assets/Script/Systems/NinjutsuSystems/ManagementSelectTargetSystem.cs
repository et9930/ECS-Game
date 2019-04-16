using System.Numerics;
using Entitas;

public class ManagementSelectTargetSystem : IExecuteSystem
{
    private readonly GameContext _context;
    public ManagementSelectTargetSystem(Contexts contexts)
    {
        _context = contexts.game;
    }
    
    public  void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null) return;

        GameEntity leftListEntity = null;
        GameEntity rightListEntity = null;
        foreach (var ui in _context.GetGroup(GameMatcher.AllOf(GameMatcher.UiRootId).NoneOf(GameMatcher.UiClose)))
        {
            if (ui.name.text == "OutScreenSelectTargetViewLeftList")
            {
                leftListEntity = ui;
            }
            else if (ui.name.text == "OutScreenSelectTargetViewRightList")
            {
                rightListEntity = ui;
            }
        }
        if (leftListEntity == null || rightListEntity == null) return;
        foreach (var e in _context.GetGroup(GameMatcher.SelectTarget))
        {
            var target = e.selectTarget.value;

            if (e.parentEntity.value.hasUiRootId)
            {
                var distance = Vector3.Distance(currentPlayer.position.value, target.position.value);
                e.ReplaceSelectTargetDistance((int) distance);
                var targetScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(target.position.value);
                if (targetScreenPosition.X >= 0 && targetScreenPosition.X <= 1920 && targetScreenPosition.Y >= 0 && targetScreenPosition.Y <= 1080)
                {
                    _context.sceneService.instance.SetUIAnchorMax(e.name.text, Vector2.Zero);
                    _context.sceneService.instance.SetUIAnchorMin(e.name.text, Vector2.Zero);
                    e.ReplaceParentEntity(target);
                    e.ReplaceUiExcursion(Vector2.Zero);
                    e.ReplaceSelectTargetDistance(-1);
                }
            }
            else
            {
                var targetScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(target.position.value);
                if (!(targetScreenPosition.X >= 0 && targetScreenPosition.X <= 1920 && targetScreenPosition.Y >= 0 && targetScreenPosition.Y <= 1080))
                {
                    e.ReplaceParentEntity(target.position.value.X < currentPlayer.position.value.X ? leftListEntity : rightListEntity);
                    var distance = Vector3.Distance(currentPlayer.position.value, target.position.value);
                    e.ReplaceSelectTargetDistance((int)distance);
                }
            }
        }
    }
}