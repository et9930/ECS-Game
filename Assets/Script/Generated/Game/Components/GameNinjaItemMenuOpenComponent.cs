//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity ninjaItemMenuOpenEntity { get { return GetGroup(GameMatcher.NinjaItemMenuOpen).GetSingleEntity(); } }

    public bool isNinjaItemMenuOpen {
        get { return ninjaItemMenuOpenEntity != null; }
        set {
            var entity = ninjaItemMenuOpenEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isNinjaItemMenuOpen = true;
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

    static readonly NinjaItemMenuOpenComponent ninjaItemMenuOpenComponent = new NinjaItemMenuOpenComponent();

    public bool isNinjaItemMenuOpen {
        get { return HasComponent(GameComponentsLookup.NinjaItemMenuOpen); }
        set {
            if (value != isNinjaItemMenuOpen) {
                var index = GameComponentsLookup.NinjaItemMenuOpen;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : ninjaItemMenuOpenComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherNinjaItemMenuOpen;

    public static Entitas.IMatcher<GameEntity> NinjaItemMenuOpen {
        get {
            if (_matcherNinjaItemMenuOpen == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NinjaItemMenuOpen);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNinjaItemMenuOpen = matcher;
            }

            return _matcherNinjaItemMenuOpen;
        }
    }
}
