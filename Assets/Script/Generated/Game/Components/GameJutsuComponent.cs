//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly JutsuComponent jutsuComponent = new JutsuComponent();

    public bool isJutsu {
        get { return HasComponent(GameComponentsLookup.Jutsu); }
        set {
            if (value != isJutsu) {
                var index = GameComponentsLookup.Jutsu;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : jutsuComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherJutsu;

    public static Entitas.IMatcher<GameEntity> Jutsu {
        get {
            if (_matcherJutsu == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Jutsu);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJutsu = matcher;
            }

            return _matcherJutsu;
        }
    }
}
