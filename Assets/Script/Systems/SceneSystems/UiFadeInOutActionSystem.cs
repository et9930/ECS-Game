using System.Collections;
using System.Collections.Generic;
using Entitas;

public class UiFadeInOutActionSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;
    
    public UiFadeInOutActionSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceFadingUiList(new List<string>());
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiFadeAction);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUiFadeAction;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_context.fadingUiList.list.Contains(e.uiFadeAction.uiName)) continue;
            _context.fadingUiList.list.Add(e.uiFadeAction.uiName);
            _context.coroutineService.instance.StartCoroutine(FadeUi(e.uiFadeAction.uiName, e.uiFadeAction.objectiveAlpha, e.uiFadeAction.changeDuration));
            e.RemoveUiFadeAction();
        }
    }

    private IEnumerator FadeUi(string uiName, float objectiveAlpha, float time)
    {
        _context.CreateEntity().ReplaceDebugMessage(uiName + " change alpha to " + objectiveAlpha);
        var oldAlpha = _context.sceneService.instance.GetUIAlpha(uiName);
        var deltaAlpha = objectiveAlpha - oldAlpha;
        var lastAlpha = oldAlpha;
        var durationTime = 0.0f;
        while (durationTime < time)
        {
            var newAlpha = lastAlpha + _context.timeService.instance.GetDeltaTime() / time * deltaAlpha;
            _context.sceneService.instance.SetUIAlpha(uiName, newAlpha);
            lastAlpha = newAlpha;
            durationTime += _context.timeService.instance.GetDeltaTime();
            yield return _context.coroutineService.instance.WaitForEndOfFrame();
        }
        _context.sceneService.instance.SetUIAlpha(uiName, objectiveAlpha);
        _context.fadingUiList.list.Remove(uiName);
    }
}