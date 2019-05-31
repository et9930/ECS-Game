using System;
using System.Collections.Generic;


public static class ListenerList
{
    public static Dictionary<string, Type> dictionary = new Dictionary<string, Type>()
    {
        { "Active", typeof(ActiveListener) },
        { "Fps", typeof(FpsListener) },
        { "Hierarchy", typeof(HierarchyListener) },
        { "Ping", typeof(PingListener) },
        { "Position", typeof(PositionListener) },
        { "Rotation", typeof(RotationListener) },
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

        { "PerceptionPositionExist", typeof(PerceptionPositionExistListener) },
        { "PerceptionPositionAccurate", typeof(PerceptionPositionAccurateListener) },
        { "PerceptionHTC", typeof(PerceptionHTCListener) },

        { "CurrentWeapon", typeof(CurrentWeaponListener) },

        { "QuickActionMenuItem", typeof(QuickActionMenuItemListener) },

        { "SelectTarget", typeof(SelectTargetListener) },

        { "CurrentPlayerUserData", typeof(CurrentPlayerUserDataListener) },

        { "ChooseNinjaWindow", typeof(ChooseNinjaWindowListener) },
        { "ChooseNinjaItem", typeof(ChooseNinjaItemListener) },
        { "PlayerChooseItem", typeof(PlayerChooseItemListener) },

        { "MatchReplayListItem", typeof(MatchReplayListItemListener) },

        { "BattleValueDisplay", typeof(BattleValueDisplayListener) },

        { "BattleSceneOver", typeof(BattleSceneOverListener) },

        { "SettingWindow", typeof(SettingWindowListener) },
    };
}

