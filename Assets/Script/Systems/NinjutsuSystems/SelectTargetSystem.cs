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
        if (_context.hasBattleOver) return;

        foreach (var e in entities)
        {
            if (e.hasJutsuTarget)
            {
                e.isStartConditionConfirm = true;
                var newJutsuControl = new MatchDataJutsuControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    originatorId = e.originator.value.id.value,
                    jutsuName = e.name.text,
                    needTarget = true,
                    targetId = e.jutsuTarget.value.id.value
                };
                _context.CreateEntity().ReplaceSendMatchData(1011, Utilities.ToJson(newJutsuControl));
                e.isDestroy = true;
                continue;
            }

            var jutsuConfig = _context.ninjutsuAttributes.dic[e.name.text];
            var targets = new List<GameEntity>();

            foreach (var target in _context.GetEntities())
            {
                if (!CheckRequireFlag(jutsuConfig, target)) continue;

                var targetMark = _context.CreateEntity();
                targetMark.ReplaceSelectTarget(target);
                targetMark.ReplaceName("SelectTarget_" + _context.jutsuSelectTargetId.value);
                targetMark.ReplaceUiOpen("SelectTarget");
                var targetScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(target.position.value);
                if (targetScreenPosition.X >= 0 && targetScreenPosition.X <= _context.viewService.instance.ScreenSize.X && targetScreenPosition.Y >= 0 && targetScreenPosition.Y <= _context.viewService.instance.ScreenSize.Y)
                {
                    targetMark.ReplaceParentEntity(target);
                }
                else
                {
                    var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
                    GameEntity listEntity = null;
                    var left = target.position.value.X < currentPlayer.position.value.X;
                    var listName = left ? "OutScreenSelectTargetViewLeftList" : "OutScreenSelectTargetViewRightList";
                    foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                    {
                        if(!ui.hasName) continue;
                        if (ui.name.text != listName) continue;
                        listEntity = ui;
                        break;
                    }
                    if (listEntity == null) continue;

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
        var newJutsuControl = new MatchDataJutsuControl
        {
            matchId = _context.currentMatchData.value.customMatchId,
            originatorId = jutsu.originator.value.id.value,
            jutsuName = jutsu.name.text,
            needTarget = true,
            targetId = jutsu.jutsuTarget.value.id.value
        };
        _context.CreateEntity().ReplaceSendMatchData(1011, Utilities.ToJson(newJutsuControl));
        jutsu.isDestroy = true;

        foreach (var e in targets)
        {
            e.isUiClose = true;
        }

        foreach (var e in _context.GetEntitiesWithName("OutScreenSelectTargetView"))
        {
            e.ReplaceActive(false);
        }

        targets.Clear();
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