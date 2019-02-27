using System;
using System.Collections.Generic;


public static class ListenerList
{
    public static Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
    {
        { "Active", typeof(ActiveListener) },
        { "Fps", typeof(FpsListener) },
        { "Hierarchy", typeof(HierarchyListener) },
        { "Position", typeof(PositionListener) },
        { "Scale", typeof(ScaleListener) },
        { "ScrollBarValue", typeof(ScrollBarValueListener) },
        { "Size", typeof(SizeListener) },
        { "Text", typeof(TextListener) },
        { "Toward", typeof(TowardListener) },

        { "LoadingSceneImage", typeof(LoadingSceneImageListener) },
        { "LoadingSceneProcess", typeof(LoadingSceneProcessListener) },
        { "LoadingSceneProcessText", typeof(LoadingSceneProcessTextListener) },
        { "LoadingSceneText", typeof(LoadingSceneTextListener) },
        { "LoadingSceneTitle", typeof(LoadingSceneTitleListener) },

        { "PlayerChaKuRa", typeof(PlayerChaKuRaListener) },
        { "PlayerHealth", typeof(PlayerHealthListener) },
        { "PlayerHeadShot", typeof(PlayerHeadShotListener) },
        { "PlayerTaiRyoKu", typeof(PlayerTaiRyoKuListener) },

        { "JumpForce", typeof(JumpForceListener) },
        { "JumpHorizontalDirectionArrow", typeof(JumpHorizontalDirectionArrowListener) },
        { "JumpVerticalDirectionArrow", typeof(JumpVerticalDirectionArrowListener) },

        { "NinjutsuMenuItem", typeof(NinjutsuMenuItemListener) },
        { "NinjutsuMenuInfo", typeof(NinjutsuMenuInfoListener) },

        { "MakeYinTime", typeof(MakeYinTimeListener) },

        { "NinjaItemMenuItem", typeof(NinjaItemMenuItemListener) },
        { "NinjaItemMenuInfo", typeof(NinjaItemMenuInfoListener) },
    };
}

