using System;
using System.Collections.Generic;


public static class ListenerList
{
    public static Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
    {
        { "LoadingSceneImage", typeof(LoadingSceneImageListener) },
        { "LoadingSceneProcess", typeof(LoadingSceneProcessListener) },
        { "LoadingSceneProcessText", typeof(LoadingSceneProcessTextListener) },
        { "LoadingSceneText", typeof(LoadingSceneTextListener) },
        { "LoadingSceneTitle", typeof(LoadingSceneTitleListener) },

        { "Active", typeof(ActiveListener) },
        { "Fps", typeof(FpsListener) },
        { "Hierarchy", typeof(HierarchyListener) },
        { "Position", typeof(PositionListener) },
        { "Scale", typeof(ScaleListener) },
        { "Text", typeof(TextListener) },
        { "Toward", typeof(TowardListener) },
    };
}

