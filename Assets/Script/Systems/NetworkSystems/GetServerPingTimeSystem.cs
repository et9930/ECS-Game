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
        var sendTimeStamp = Utilities.GetTimeStamp();
        var payload = await _context.networkService.instance.RpcCall("rpc_ping", null, true);
        if (payload == null)
        {
            foreach (var e in _context.GetEntitiesWithName("NormalNetworkIcon"))
            {
                e.ReplaceActive(false);
            }
            foreach (var e in _context.GetEntitiesWithName("ErrorNetworkIcon"))
            {
                e.ReplaceActive(true);
            }
            _context.ReplaceCurrentPingTime(999);
        }
        else
        {
            foreach (var e in _context.GetEntitiesWithName("NormalNetworkIcon"))
            {
                e.ReplaceActive(true);
            }
            foreach (var e in _context.GetEntitiesWithName("ErrorNetworkIcon"))
            {
                e.ReplaceActive(false);
            }
            var scPing = Utilities.ParseJson<SCPing>(payload);
            //        _context.CreateEntity().ReplaceDebugMessage(sendTimeStamp.ToString());
            //        _context.CreateEntity().ReplaceDebugMessage(scPing.timeStamp.ToString());
            var deltaTime = (int)((scPing.timeStamp - sendTimeStamp) * 2);
            _context.ReplaceCurrentPingTime(deltaTime);
        }
    }
}