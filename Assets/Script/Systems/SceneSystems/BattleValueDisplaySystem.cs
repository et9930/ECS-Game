using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class BattleValueDisplaySystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public BattleValueDisplaySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceBattleValueDisplayNumber(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BattleValueDisplay);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBattleValueDisplay && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceName("BattleValueDisplay" + _context.battleValueDisplayNumber.value);
            _context.ReplaceBattleValueDisplayNumber(_context.battleValueDisplayNumber.value + 1);
            e.ReplaceUiOpen("BattleValueDisplay");
            e.ReplaceParentEntity(e.battleValueDisplay.parent);
            e.ReplaceUiExcursion(new Vector2(Utilities.RandomFloat(0, 30), Utilities.RandomFloat(80, 120)));
            _context.coroutineService.instance.StartCoroutine(StartMove(e));
        }
    }

    private IEnumerator StartMove(GameEntity e)
    {
        yield return _context.coroutineService.instance.WaitForSeconds(1);

//        e.ReplaceUiMoveAction(e.name.text, true, new Vector2(0, 200), 2);
        e.ReplaceUiFadeAction(e.name.text, 0, 2);

        yield return _context.coroutineService.instance.WaitForSeconds(2.5f);

        e.isUiClose = true;
    }
}