using System;
using System.Collections.Generic;


public static class ListenerList
{
    public static Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
    {
        { "LoadingSceneImage", typeof(LoadingSceneImageListener) },
        { "LoadingSceneProcess", typeof(LoadingSceneProcessListener) },
        { "LoadingSceneText", typeof(LoadingSceneTextListener) },
        { "LoadingSceneTitle", typeof(LoadingSceneTitleListener) },
        { "LoadingSceneProcessText", typeof(LoadingSceneProcessTextListener) },

        { "Active", typeof(ActiveListener) },
        { "Position", typeof(PositionListener) },
        { "Text", typeof(TextListener) },
    };
}

