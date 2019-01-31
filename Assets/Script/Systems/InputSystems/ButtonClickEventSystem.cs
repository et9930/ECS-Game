using System;
using Entitas;
using System.Collections.Generic;

public class ButtonClickEventSystem : ReactiveSystem<GameEntity>, IInitializeSystem 
{
    private readonly GameContext _context;

    public ButtonClickEventSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceButtonClickEventFunc(new Dictionary<string, Action>());
        _context.buttonClickEventFunc.buttonClickDic.Add("TestButton", TestButtonOnClick);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ButtonClickState);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasButtonClickState && entity.buttonClickState.value;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceButtonClickState(false);
            _context.buttonClickEventFunc.buttonClickDic[e.name.text]();
        }
    }

    private void TestButtonOnClick()
    {
        _context.CreateEntity().ReplaceDebugMessage("Test Button Click");
    }
}
