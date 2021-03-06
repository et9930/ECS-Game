//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity settingWindowOpenEntity { get { return GetGroup(GameMatcher.SettingWindowOpen).GetSingleEntity(); } }

    public bool isSettingWindowOpen {
        get { return settingWindowOpenEntity != null; }
        set {
            var entity = settingWindowOpenEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isSettingWindowOpen = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SettingWindowOpenComponent settingWindowOpenComponent = new SettingWindowOpenComponent();

    public bool isSettingWindowOpen {
        get { return HasComponent(GameComponentsLookup.SettingWindowOpen); }
        set {
            if (value != isSettingWindowOpen) {
                var index = GameComponentsLookup.SettingWindowOpen;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : settingWindowOpenComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSettingWindowOpen;

    public static Entitas.IMatcher<GameEntity> SettingWindowOpen {
        get {
            if (_matcherSettingWindowOpen == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SettingWindowOpen);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSettingWindowOpen = matcher;
            }

            return _matcherSettingWindowOpen;
        }
    }
}
