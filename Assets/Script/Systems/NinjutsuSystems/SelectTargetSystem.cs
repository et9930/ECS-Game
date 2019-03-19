using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class SelectTargetSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public SelectTargetSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceJutsuSelectTargetId(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Jutsu);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isJutsu && !entity.isStartConditionConfirm && !entity.isDestroy && entity.hasName;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var jutsuConfig = _context.ninjutsuAttributes.dic[e.name.text];
            var targets = new List<GameEntity>();

            foreach (var target in _context.GetEntities())
            {
                if (!CheckRequireFlag(jutsuConfig, target)) continue;

                var targetMark = _context.CreateEntity();
                targetMark.ReplaceSelectTarget(target);
                var targetScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(target.position.value);
                if (targetScreenPosition.X >= 0 && targetScreenPosition.X <= 1920 && targetScreenPosition.Y >= 0 && targetScreenPosition.Y <= 1080)
                {
                    targetMark.ReplaceParentEntity(target);
                    targetMark.ReplaceName("SelectTarget_" + _context.jutsuSelectTargetId.value);
                    targetMark.ReplaceUiOpen("SelectTarget");
                }
                else
                {
                    var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
                    GameEntity listEntity = null;
                    var left = target.position.value.X < currentPlayer.position.value.X;
                    var listName = left ? "OutScreenSelectTargetViewLeftList" : "OutScreenSelectTargetViewRightList";
                    foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                    {
                        if (ui.name.text != listName) continue;
                        listEntity = ui;
                        break;
                    }
                    if (listEntity == null) continue;

                    targetMark.ReplaceName("OutScreenSelectTarget_" + _context.jutsuSelectTargetId.value);
                    targetMark.ReplaceUiOpen("OutScreenSelectTarget");
                    targetMark.ReplaceParentEntity(listEntity);
                }

                targets.Add(targetMark);
                _context.ReplaceJutsuSelectTargetId(_context.jutsuSelectTargetId.value + 1);

            }

            if (targets.Count == 0)
            {
                e.isDestroy = true;
                continue;
            }
            _context.coroutineService.instance.StartCoroutine(WaitSelectTarget(targets, e));
        }
    }

    private bool CheckRequireFlag(Ninjutsu jutsu, GameEntity e)
    {
        if (jutsu.targetFlag != null)
        {
            foreach (var trueFlag in jutsu.targetFlag)
            {
                var index = Array.IndexOf(GameComponentsLookup.componentNames, trueFlag);
                if (!e.HasComponent(index))
                    return false;
            }
        }

        if (jutsu.targetNoFlag != null)
        {
            foreach (var falseFlag in jutsu.targetNoFlag)
            {
                var index = Array.IndexOf(GameComponentsLookup.componentNames, falseFlag);
                if (e.HasComponent(index))
                    return false;
            }
        }

        return true;
    }

    private IEnumerator WaitSelectTarget(List<GameEntity> targets, GameEntity jutsu)
    {
        yield return _context.coroutineService.instance.WaitUntil(() => CheckSelectState(targets, jutsu));

        jutsu.isStartConditionConfirm = true;

        foreach (var e in targets)
        {
            e.isUiClose = true;
        }

//        targets.Clear();
    }

    private bool CheckSelectState(List<GameEntity> targets, GameEntity jutsu)
    {
        foreach (var e in targets)
        {
            if (!e.isSelected) continue;

            jutsu.ReplaceJutsuTarget(e.selectTarget.value);
            return true;
        }

        return false;
    }


}