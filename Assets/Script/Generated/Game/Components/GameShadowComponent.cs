//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ShadowComponent shadowComponent = new ShadowComponent();

    public bool isShadow {
        get { return HasComponent(GameComponentsLookup.Shadow); }
        set {
            if (value != isShadow) {
                var index = GameComponentsLookup.Shadow;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : shadowComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherShadow;

    public static Entitas.IMatcher<GameEntity> Shadow {
        get {
            if (_matcherShadow == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Shadow);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherShadow = matcher;
            }

            return _matcherShadow;
        }
    }
}
