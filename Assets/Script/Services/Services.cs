public class Services
{
    public readonly ILogService Log;
    public readonly IViewService View;
    public readonly IMouseInputService MouseInput;
    public readonly ILoadConfigService LoadConfig;
    public readonly ISceneService Scene;
    public readonly ICoroutineService Coroutine;
    public readonly IKeyInputService KeyInput;
    public readonly ITimeService Time;
    public readonly IPhysicsService Physics;
    public readonly INetworkService Network;
    public readonly ILocalStorageService LocalStorage;
    public readonly IFileService File;

    public Services(ILogService log, IViewService view, IMouseInputService mouseInput, ILoadConfigService loadConfig, ISceneService scene, ICoroutineService coroutine, IKeyInputService keyInput, ITimeService time, IPhysicsService physics, INetworkService network, ILocalStorageService localStorage, IFileService file)
    {
        Log = log;
        View = view;
        MouseInput = mouseInput;
        LoadConfig = loadConfig;
        Scene = scene;
        Coroutine = coroutine;
        KeyInput = keyInput;
        Time = time;
        Physics = physics;
        Network = network;
        LocalStorage = localStorage;
        File = file;
    }
}
