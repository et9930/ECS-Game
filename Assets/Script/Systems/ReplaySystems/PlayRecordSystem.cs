using System.Linq;
using Entitas;

public class PlayRecordSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public PlayRecordSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.isReplaying) return;
        if (!_context.hasReplayStartTime) return;

        var deltaTime = _context.timeService.instance.GetLocalTimeStamp() - _context.replayStartTime.value;
        var record = _context.currentReplayData.value.matchRecord;
        while (record.Count > 0 && record.First().time <= deltaTime)
        {
            var recordItem = record.First();
            record.RemoveAt(0);
            _context.CreateEntity().ReplaceMatchData(recordItem.opCode, recordItem.data);
        }
    }
}