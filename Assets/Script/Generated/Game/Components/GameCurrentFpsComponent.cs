//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity currentFpsEntity { get { return GetGroup(GameMatcher.CurrentFps).GetSingleEntity(); } }
    public CurrentFpsComponent currentFps { get { return currentFpsEntity.currentFps; } }
    public bool hasCurrentFps { get { return currentFpsEntity != null; } }

    public GameEntity SetCurrentFps(float newValue) {
        if (hasCurrentFps) {
            throw new Entitas.EntitasException("Could not set CurrentFps!\n" + this + " already has an entity with CurrentFpsComponent!",
                "You should check if the context already has a currentFpsEntity before setting it or use context.ReplaceCurrentFps().");
        }
        var entity = CreateEntity();
        entity.AddCurrentFps(newValue);
        return entity;
    }

    public void ReplaceCurrentFps(float newValue) {
        var entity = currentFpsEntity;
        if (entity == null) {
            entity = SetCurrentFps(newValue);
        } else {
            entity.ReplaceCurrentFps(newValue);
        }
    }

    public void RemoveCurrentFps() {
        currentFpsEntity.Destroy();
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

    public CurrentFpsComponent currentFps { get { return (CurrentFpsComponent)GetComponent(GameComponentsLookup.CurrentFps); } }
    public bool hasCurrentFps { get { return HasComponent(GameComponentsLookup.CurrentFps); } }

    public void AddCurrentFps(float newValue) {
        var index = GameComponentsLookup.CurrentFps;
        var component = (CurrentFpsComponent)CreateComponent(index, typeof(CurrentFpsComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentFps(float newValue) {
        var index = GameComponentsLookup.CurrentFps;
        var component = (CurrentFpsComponent)CreateComponent(index, typeof(CurrentFpsComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentFps() {
        RemoveComponent(GameComponentsLookup.CurrentFps);
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentFps;

    public static Entitas.IMatcher<GameEntity> CurrentFps {
        get {
            if (_matcherCurrentFps == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentFps);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentFps = matcher;
            }

            return _matcherCurrentFps;
        }
    }
}
