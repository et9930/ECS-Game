//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity collisionPairConfigEntity { get { return GetGroup(GameMatcher.CollisionPairConfig).GetSingleEntity(); } }
    public CollisionPairConfigComponent collisionPairConfig { get { return collisionPairConfigEntity.collisionPairConfig; } }
    public bool hasCollisionPairConfig { get { return collisionPairConfigEntity != null; } }

    public GameEntity SetCollisionPairConfig(System.Collections.Generic.List<CollisionPair> newList) {
        if (hasCollisionPairConfig) {
            throw new Entitas.EntitasException("Could not set CollisionPairConfig!\n" + this + " already has an entity with CollisionPairConfigComponent!",
                "You should check if the context already has a collisionPairConfigEntity before setting it or use context.ReplaceCollisionPairConfig().");
        }
        var entity = CreateEntity();
        entity.AddCollisionPairConfig(newList);
        return entity;
    }

    public void ReplaceCollisionPairConfig(System.Collections.Generic.List<CollisionPair> newList) {
        var entity = collisionPairConfigEntity;
        if (entity == null) {
            entity = SetCollisionPairConfig(newList);
        } else {
            entity.ReplaceCollisionPairConfig(newList);
        }
    }

    public void RemoveCollisionPairConfig() {
        collisionPairConfigEntity.Destroy();
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

    public CollisionPairConfigComponent collisionPairConfig { get { return (CollisionPairConfigComponent)GetComponent(GameComponentsLookup.CollisionPairConfig); } }
    public bool hasCollisionPairConfig { get { return HasComponent(GameComponentsLookup.CollisionPairConfig); } }

    public void AddCollisionPairConfig(System.Collections.Generic.List<CollisionPair> newList) {
        var index = GameComponentsLookup.CollisionPairConfig;
        var component = (CollisionPairConfigComponent)CreateComponent(index, typeof(CollisionPairConfigComponent));
        component.list = newList;
        AddComponent(index, component);
    }

    public void ReplaceCollisionPairConfig(System.Collections.Generic.List<CollisionPair> newList) {
        var index = GameComponentsLookup.CollisionPairConfig;
        var component = (CollisionPairConfigComponent)CreateComponent(index, typeof(CollisionPairConfigComponent));
        component.list = newList;
        ReplaceComponent(index, component);
    }

    public void RemoveCollisionPairConfig() {
        RemoveComponent(GameComponentsLookup.CollisionPairConfig);
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

    static Entitas.IMatcher<GameEntity> _matcherCollisionPairConfig;

    public static Entitas.IMatcher<GameEntity> CollisionPairConfig {
        get {
            if (_matcherCollisionPairConfig == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollisionPairConfig);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollisionPairConfig = matcher;
            }

            return _matcherCollisionPairConfig;
        }
    }
}
