using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class SwitchChooseNinjaWindowSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public SwitchChooseNinjaWindowSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllocationNinjaNotification);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAllocationNinjaNotification;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.coroutineService.instance.StartCoroutine(SwitchChooseNinjaWindow(e.allocationNinjaNotification.value));
        }
    }

    private IEnumerator SwitchChooseNinjaWindow(SCAllocationNinja allocationNinja)
    {
        yield return _context.coroutineService.instance.WaitForSeconds(2);
        var e = _context.CreateEntity();
        e.ReplaceUiOpen("ChooseNinjaWindow");
        e.ReplaceName("ChooseNinjaWindow");
        foreach (var ui in _context.GetEntitiesWithName("SearchBattleWindow"))
        {
            ui.isUiClose = true;
        }

        yield return _context.coroutineService.instance.WaitForEndOfFrame();
        yield return _context.coroutineService.instance.WaitForEndOfFrame();

        GameEntity ninjaList = null;
        GameEntity friendlyList = null;
        GameEntity enemyList = null;
        var selfTeam = 0;

        foreach (var entity in _context.GetEntitiesWithName("ChooseNinjaWindowNinjaList"))
        {
            ninjaList = entity;
            break;
        }
        foreach (var entity in _context.GetEntitiesWithName("ChooseNinjaWindowFriendlyList"))
        {
            friendlyList = entity;
            break;
        }
        foreach (var entity in _context.GetEntitiesWithName("ChooseNinjaWindowEnemyList"))
        {
            enemyList = entity;
            break;
        }

        foreach (var player in _context.currentMatchData.value.matchPlayers)
        {
            if (player.userId != _context.currentPlayerId.value) continue;
            selfTeam = player.team;
            break;
        }

        if (ninjaList == null || friendlyList == null || enemyList == null) yield break;

        foreach (var ninjaItem in allocationNinja.ninjaList)
        {
            var ui = _context.CreateEntity();
            ui.ReplaceUiOpen("ChooseNinjaItem");
            ui.ReplaceName("ChooseNinjaItem");
            ui.ReplaceChooseNinjaItemInfo(ninjaItem);
            ui.ReplaceParentEntity(ninjaList);
        }

        foreach (var player in _context.currentMatchData.value.matchPlayers)
        {
            var ui = _context.CreateEntity();
            ui.ReplaceUiOpen("PlayerChooseItem");
            ui.ReplaceName("PlayerChooseItem");
            ui.ReplacePlayerChooseNinjaInfo(player.userId, "");
            ui.ReplaceParentEntity(player.team == selfTeam ? friendlyList : enemyList);
        }

        _context.ReplaceAllocationNinja(allocationNinja);
    }
}