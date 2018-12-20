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

    public Services(ILogService log, IViewService view, IMouseInputService mouseInput)
    {
        Log = log;
        View = view;
        MouseInput = mouseInput;
    }
}
