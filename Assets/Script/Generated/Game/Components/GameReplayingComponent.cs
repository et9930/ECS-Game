//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity replayingEntity { get { return GetGroup(GameMatcher.Replaying).GetSingleEntity(); } }

    public bool isReplaying {
        get { return replayingEntity != null; }
        set {
            var entity = replayingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isReplaying = true;
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

    static readonly ReplayingComponent replayingComponent = new ReplayingComponent();

    public bool isReplaying {
        get { return HasComponent(GameComponentsLookup.Replaying); }
        set {
            if (value != isReplaying) {
                var index = GameComponentsLookup.Replaying;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : replayingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherReplaying;

    public static Entitas.IMatcher<GameEntity> Replaying {
        get {
            if (_matcherReplaying == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Replaying);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReplaying = matcher;
            }

            return _matcherReplaying;
        }
    }
}
