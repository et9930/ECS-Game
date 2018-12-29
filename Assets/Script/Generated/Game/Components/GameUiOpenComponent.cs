//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly UiOpenComponent uiOpenComponent = new UiOpenComponent();

    public bool isUiOpen {
        get { return HasComponent(GameComponentsLookup.UiOpen); }
        set {
            if (value != isUiOpen) {
                var index = GameComponentsLookup.UiOpen;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : uiOpenComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherUiOpen;

    public static Entitas.IMatcher<GameEntity> UiOpen {
        get {
            if (_matcherUiOpen == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UiOpen);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUiOpen = matcher;
            }

            return _matcherUiOpen;
        }
    }
}