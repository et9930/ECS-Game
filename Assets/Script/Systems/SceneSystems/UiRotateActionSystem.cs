using System.Collections;
using System.Collections.Generic;
using Entitas;

public class UiRotateActionSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;  

    public UiRotateActionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceRotatingUiList(new List<string>());
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiRotateAction);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUiRotateAction;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_context.rotatingUiList.list.Contains(e.uiRotateAction.uiName)) continue;
            _context.rotatingUiList.list.Add(e.uiRotateAction.uiName);
            _context.coroutineService.instance.StartCoroutine(RotateUI(e.uiRotateAction.uiName, e.uiRotateAction.rotateAngle, e.uiRotateAction.rotateDuration));
            e.RemoveUiRotateAction();
        }
    }

    private IEnumerator RotateUI(string uiName, float angle, float time)
    {
        _context.CreateEntity().ReplaceDebugMessage(uiName + " rotate " + angle);
        var oldAngle = _context.sceneService.instance.GetUIAngle(uiName);
        var finalAngle = oldAngle + angle;
//        _context.CreateEntity().ReplaceDebugMessage(oldAngle + " " + finalAngle);
        var lastAngle = oldAngle;
        var durationTime = 0.0f;
        while (durationTime < time)
        {
            var newAngle = lastAngle + _context.timeService.instance.GetDeltaTime() / time * angle;
            
            _context.sceneService.instance.SetUIAngle(uiName, newAngle);
            lastAngle = newAngle;
            durationTime += _context.timeService.instance.GetDeltaTime();
            yield return _context.coroutineService.instance.WaitForEndOfFrame();
        }
        _context.sceneService.instance.SetUIAngle(uiName, finalAngle);
        _context.rotatingUiList.list.Remove(uiName);
    }
}