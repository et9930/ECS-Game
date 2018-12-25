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
    public readonly ISceneService scene;

    public Services(ILogService log, IViewService view, IMouseInputService mouseInput, ILoadConfigService loadConfig, ISceneService scene)
    {
        Log = log;
        View = view;
        MouseInput = mouseInput;
        LoadConfig = loadConfig;
        this.scene = scene;
    }
}
