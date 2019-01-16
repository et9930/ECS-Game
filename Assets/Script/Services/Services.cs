using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public Services(ILogService log, IViewService view, IMouseInputService mouseInput, ILoadConfigService loadConfig, ISceneService scene, ICoroutineService coroutine, IKeyInputService keyInput, ITimeService time)
    {
        Log = log;
        View = view;
        MouseInput = mouseInput;
        LoadConfig = loadConfig;
        Scene = scene;
        Coroutine = coroutine;
        KeyInput = keyInput;
        Time = time;
    }
}
