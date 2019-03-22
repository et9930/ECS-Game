using System;
using Entitas;

public class GetServerPingTimeSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;

    public GetServerPingTimeSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceLastGetPingTime(0);
    }

    public void Execute()
    {
        var currentTime = _context.timeService.instance.GetRealTimeSinceStartup();
        if (currentTime - _context.lastGetPingTime.value < 1.0f) return;

        _context.ReplaceLastGetPingTime(currentTime);
        GetPingTime();
    }

    private async void GetPingTime()
    {
        var sendTimeStamp = DateTime.Now.Millisecond;
        var returnCode = await _context.networkService.instance.Ping();
        switch (returnCode)
        {
            case 400:
                var receiveTimeStamp = DateTime.Now.Millisecond;
                var pingTime = receiveTimeStamp - sendTimeStamp;
                _context.ReplaceCurrentPingTime(pingTime);
                return;
            case 407:
                // 丢包
                return;
            default:
                return;
        }
    }
}