//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity currentPingTimeEntity { get { return GetGroup(GameMatcher.CurrentPingTime).GetSingleEntity(); } }
    public CurrentPingTimeComponent currentPingTime { get { return currentPingTimeEntity.currentPingTime; } }
    public bool hasCurrentPingTime { get { return currentPingTimeEntity != null; } }

    public GameEntity SetCurrentPingTime(int newValue) {
        if (hasCurrentPingTime) {
            throw new Entitas.EntitasException("Could not set CurrentPingTime!\n" + this + " already has an entity with CurrentPingTimeComponent!",
                "You should check if the context already has a currentPingTimeEntity before setting it or use context.ReplaceCurrentPingTime().");
        }
        var entity = CreateEntity();
        entity.AddCurrentPingTime(newValue);
        return entity;
    }

    public void ReplaceCurrentPingTime(int newValue) {
        var entity = currentPingTimeEntity;
        if (entity == null) {
            entity = SetCurrentPingTime(newValue);
        } else {
            entity.ReplaceCurrentPingTime(newValue);
        }
    }

    public void RemoveCurrentPingTime() {
        currentPingTimeEntity.Destroy();
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

    public CurrentPingTimeComponent currentPingTime { get { return (CurrentPingTimeComponent)GetComponent(GameComponentsLookup.CurrentPingTime); } }
    public bool hasCurrentPingTime { get { return HasComponent(GameComponentsLookup.CurrentPingTime); } }

    public void AddCurrentPingTime(int newValue) {
        var index = GameComponentsLookup.CurrentPingTime;
        var component = (CurrentPingTimeComponent)CreateComponent(index, typeof(CurrentPingTimeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentPingTime(int newValue) {
        var index = GameComponentsLookup.CurrentPingTime;
        var component = (CurrentPingTimeComponent)CreateComponent(index, typeof(CurrentPingTimeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentPingTime() {
        RemoveComponent(GameComponentsLookup.CurrentPingTime);
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentPingTime;

    public static Entitas.IMatcher<GameEntity> CurrentPingTime {
        get {
            if (_matcherCurrentPingTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentPingTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentPingTime = matcher;
            }

            return _matcherCurrentPingTime;
        }
    }
}