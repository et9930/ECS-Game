//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly TryThrowWeaponComponent tryThrowWeaponComponent = new TryThrowWeaponComponent();

    public bool isTryThrowWeapon {
        get { return HasComponent(GameComponentsLookup.TryThrowWeapon); }
        set {
            if (value != isTryThrowWeapon) {
                var index = GameComponentsLookup.TryThrowWeapon;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : tryThrowWeaponComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherTryThrowWeapon;

    public static Entitas.IMatcher<GameEntity> TryThrowWeapon {
        get {
            if (_matcherTryThrowWeapon == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TryThrowWeapon);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTryThrowWeapon = matcher;
            }

            return _matcherTryThrowWeapon;
        }
    }
}
