using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class AddReplayListItemSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddReplayListItemSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ReplayList);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasReplayList && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var replayList = e.replayList.value.replayList;
            
            foreach (var ui in _context.GetEntitiesWithName("MatchReplayListWindowWaitingServer"))
            {
                ui.ReplaceActive(false);
            }

            GameEntity replayListContent = null;
            GameEntity replayScrollBar = null;

            foreach (var ui in _context.GetEntitiesWithName("MatchReplayListWindowScrollbar"))
            {
                replayScrollBar = ui;
                break;
            }

            foreach (var ui in _context.GetEntitiesWithName("MatchReplayListWindowContent"))
            {
                replayListContent = ui;
                break;
            }

            if(replayScrollBar == null || replayListContent == null) continue;

            for (var index = 0; index < replayList.Count; index++)
            {
                var itemEntity = _context.CreateEntity();
                itemEntity.ReplaceName("MatchReplayListItem");
                itemEntity.ReplaceUiOpen("MatchReplayListItem");
                itemEntity.ReplaceParentEntity(replayListContent);
                itemEntity.ReplaceMatchReplayListItem(index + 1, replayList[index]);
            }

            var height = replayList.Count * 51 - 1;
            if (height < 385)
            {
                height = 385;
            }

            replayListContent.ReplaceSize(new Vector2(820, height));
            _context.coroutineService.instance.StartCoroutine(SetScrollBarValue(replayScrollBar));
            //_context.sceneService.instance.SetScrollBarSize("MatchReplayListWindowScrollbar", 385.0f / height);

        }
    }

    private IEnumerator SetScrollBarValue(GameEntity replayScrollBar)
    {
        yield return _context.coroutineService.instance.WaitForEndOfFrame();
        replayScrollBar.ReplaceScrollBarValue(1.0f);
    }
}