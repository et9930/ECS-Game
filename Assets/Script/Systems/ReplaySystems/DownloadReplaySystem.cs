using System;
using System.Collections.Generic;
using Entitas;

public class DownloadReplaySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public DownloadReplaySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DownloadReplay);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDownloadReplay && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDestroy = true;
            DownloadReplay(e.downloadReplay.matchId);
        }
    }

    private async void DownloadReplay(string matchId)
    {
        var getMatchReplay = new CSGetMatchReplay
        {
            matchId = matchId
        };

        var rpcPayload = await _context.networkService.instance.RpcCall("rpc_get_match_replay", Utilities.ToJson(getMatchReplay));

        _context.fileService.instance.SaveMatchFile(rpcPayload, matchId);
        matchId = _context.selectedReplayItem.entity.matchReplayListItem.matchData.customMatchId;
        if (_context.fileService.instance.CheckSavedFile(matchId))
        {
            foreach (var e in _context.GetEntitiesWithName("MatchReplayListWindowReplayButton"))
            {
                e.ReplaceActive(true);
            }
            _context.sceneService.instance.SetSelectableInteractable("MatchReplayListWindowReplayButton", true);
            foreach (var e in _context.GetEntitiesWithName("MatchReplayListWindowDownloadButton"))
            {
                e.ReplaceActive(false);
            }
            _context.sceneService.instance.SetSelectableInteractable("MatchReplayListWindowDownloadButton", false);
        }
        else
        {
            foreach (var e in _context.GetEntitiesWithName("MatchReplayListWindowReplayButton"))
            {
                e.ReplaceActive(false);
            }

            _context.sceneService.instance.SetSelectableInteractable("MatchReplayListWindowReplayButton", false);

            foreach (var e in _context.GetEntitiesWithName("MatchReplayListWindowDownloadButton"))
            {
                e.ReplaceActive(true);
            }

            _context.sceneService.instance.SetSelectableInteractable("MatchReplayListWindowDownloadButton", true);
        }
    }
}