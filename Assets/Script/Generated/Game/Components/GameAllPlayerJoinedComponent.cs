//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity allPlayerJoinedEntity { get { return GetGroup(GameMatcher.AllPlayerJoined).GetSingleEntity(); } }

    public bool isAllPlayerJoined {
        get { return allPlayerJoinedEntity != null; }
        set {
            var entity = allPlayerJoinedEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isAllPlayerJoined = true;
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

    static readonly AllPlayerJoinedComponent allPlayerJoinedComponent = new AllPlayerJoinedComponent();

    public bool isAllPlayerJoined {
        get { return HasComponent(GameComponentsLookup.AllPlayerJoined); }
        set {
            if (value != isAllPlayerJoined) {
                var index = GameComponentsLookup.AllPlayerJoined;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : allPlayerJoinedComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherAllPlayerJoined;

    public static Entitas.IMatcher<GameEntity> AllPlayerJoined {
        get {
            if (_matcherAllPlayerJoined == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AllPlayerJoined);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAllPlayerJoined = matcher;
            }

            return _matcherAllPlayerJoined;
        }
    }
}
