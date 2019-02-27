//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity ninjaItemMenuOpenFreezingEntity { get { return GetGroup(GameMatcher.NinjaItemMenuOpenFreezing).GetSingleEntity(); } }

    public bool isNinjaItemMenuOpenFreezing {
        get { return ninjaItemMenuOpenFreezingEntity != null; }
        set {
            var entity = ninjaItemMenuOpenFreezingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isNinjaItemMenuOpenFreezing = true;
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

    static readonly NinjaItemMenuOpenFreezingComponent ninjaItemMenuOpenFreezingComponent = new NinjaItemMenuOpenFreezingComponent();

    public bool isNinjaItemMenuOpenFreezing {
        get { return HasComponent(GameComponentsLookup.NinjaItemMenuOpenFreezing); }
        set {
            if (value != isNinjaItemMenuOpenFreezing) {
                var index = GameComponentsLookup.NinjaItemMenuOpenFreezing;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : ninjaItemMenuOpenFreezingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherNinjaItemMenuOpenFreezing;

    public static Entitas.IMatcher<GameEntity> NinjaItemMenuOpenFreezing {
        get {
            if (_matcherNinjaItemMenuOpenFreezing == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NinjaItemMenuOpenFreezing);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNinjaItemMenuOpenFreezing = matcher;
            }

            return _matcherNinjaItemMenuOpenFreezing;
        }
    }
}
