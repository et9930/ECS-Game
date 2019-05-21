using System.Collections.Generic;
using Entitas;

public class ReplayMatchRecordSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReplayMatchRecordSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.StartReplay);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasStartReplay && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var matchId = e.startReplay.matchData.customMatchId;
            if (! _context.fileService.instance.CheckSavedFile(matchId)) continue;
            _context.ReplaceCurrentMatchData(e.startReplay.matchData);
            var strRecordData = _context.fileService.instance.ReadSavedMatch(matchId);
            var recordData = Utilities.ParseJson<SCMatchRecord>(strRecordData);
            _context.ReplaceCurrentReplayData(recordData);
            _context.isReplaying = true;
            _context.ReplaceLoadScene("BattleScene");
        }
    }
}