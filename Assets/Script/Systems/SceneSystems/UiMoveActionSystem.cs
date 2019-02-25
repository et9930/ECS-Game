using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class UiMoveActionSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;
    
    public UiMoveActionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceMovingUiList(new List<string>());
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiMoveAction);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUiMoveAction;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_context.movingUiList.list.Contains(e.uiMoveAction.uiName)) continue;
            _context.movingUiList.list.Add(e.uiMoveAction.uiName);
            _context.coroutineService.instance.StartCoroutine(MoveUi(e.uiMoveAction.uiName, e.uiMoveAction.moveFor ? e.uiMoveAction.moveLocation : e.uiMoveAction.moveLocation - _context.sceneService.instance.GetUIPosition(e.uiMoveAction.uiName), e.uiMoveAction.moveDuration));
            e.RemoveUiMoveAction();
        }
    }   

    private IEnumerator MoveUi(string uiName, Vector2 forLocation, float time)
    {
        _context.CreateEntity().ReplaceDebugMessage(uiName + " move to " + forLocation);
        var oldPosition = _context.sceneService.instance.GetUIPosition(uiName);
        var finalPosition = oldPosition + forLocation;
        var lastPosition = oldPosition;
        var durationTime = 0.0f;
        while (durationTime < time)
        {
            var newPosition = lastPosition + _context.timeService.instance.GetDeltaTime() / time * forLocation;
            if (Math.Abs(newPosition.X - oldPosition.X) > Math.Abs(finalPosition.X - oldPosition.X) || Math.Abs(newPosition.Y - oldPosition.Y) > Math.Abs(finalPosition.Y - oldPosition.Y))
            {
                _context.sceneService.instance.SetUIPosition(uiName, forLocation);
                break;
            }
            _context.sceneService.instance.SetUIPosition(uiName, newPosition);
            lastPosition = newPosition;
            durationTime += _context.timeService.instance.GetDeltaTime();
            yield return _context.coroutineService.instance.WaitForEndOfFrame();
        }
        _context.sceneService.instance.SetUIPosition(uiName, finalPosition);
        _context.movingUiList.list.Remove(uiName);
    }


}