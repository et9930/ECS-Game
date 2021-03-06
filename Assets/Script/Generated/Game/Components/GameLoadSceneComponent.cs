//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity loadSceneEntity { get { return GetGroup(GameMatcher.LoadScene).GetSingleEntity(); } }
    public LoadSceneComponent loadScene { get { return loadSceneEntity.loadScene; } }
    public bool hasLoadScene { get { return loadSceneEntity != null; } }

    public GameEntity SetLoadScene(string newName) {
        if (hasLoadScene) {
            throw new Entitas.EntitasException("Could not set LoadScene!\n" + this + " already has an entity with LoadSceneComponent!",
                "You should check if the context already has a loadSceneEntity before setting it or use context.ReplaceLoadScene().");
        }
        var entity = CreateEntity();
        entity.AddLoadScene(newName);
        return entity;
    }

    public void ReplaceLoadScene(string newName) {
        var entity = loadSceneEntity;
        if (entity == null) {
            entity = SetLoadScene(newName);
        } else {
            entity.ReplaceLoadScene(newName);
        }
    }

    public void RemoveLoadScene() {
        loadSceneEntity.Destroy();
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

    public LoadSceneComponent loadScene { get { return (LoadSceneComponent)GetComponent(GameComponentsLookup.LoadScene); } }
    public bool hasLoadScene { get { return HasComponent(GameComponentsLookup.LoadScene); } }

    public void AddLoadScene(string newName) {
        var index = GameComponentsLookup.LoadScene;
        var component = (LoadSceneComponent)CreateComponent(index, typeof(LoadSceneComponent));
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplaceLoadScene(string newName) {
        var index = GameComponentsLookup.LoadScene;
        var component = (LoadSceneComponent)CreateComponent(index, typeof(LoadSceneComponent));
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemoveLoadScene() {
        RemoveComponent(GameComponentsLookup.LoadScene);
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

    static Entitas.IMatcher<GameEntity> _matcherLoadScene;

    public static Entitas.IMatcher<GameEntity> LoadScene {
        get {
            if (_matcherLoadScene == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LoadScene);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLoadScene = matcher;
            }

            return _matcherLoadScene;
        }
    }
}
