//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity replayStartTimeEntity { get { return GetGroup(GameMatcher.ReplayStartTime).GetSingleEntity(); } }
    public ReplayStartTimeComponent replayStartTime { get { return replayStartTimeEntity.replayStartTime; } }
    public bool hasReplayStartTime { get { return replayStartTimeEntity != null; } }

    public GameEntity SetReplayStartTime(double newValue) {
        if (hasReplayStartTime) {
            throw new Entitas.EntitasException("Could not set ReplayStartTime!\n" + this + " already has an entity with ReplayStartTimeComponent!",
                "You should check if the context already has a replayStartTimeEntity before setting it or use context.ReplaceReplayStartTime().");
        }
        var entity = CreateEntity();
        entity.AddReplayStartTime(newValue);
        return entity;
    }

    public void ReplaceReplayStartTime(double newValue) {
        var entity = replayStartTimeEntity;
        if (entity == null) {
            entity = SetReplayStartTime(newValue);
        } else {
            entity.ReplaceReplayStartTime(newValue);
        }
    }

    public void RemoveReplayStartTime() {
        replayStartTimeEntity.Destroy();
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

    public ReplayStartTimeComponent replayStartTime { get { return (ReplayStartTimeComponent)GetComponent(GameComponentsLookup.ReplayStartTime); } }
    public bool hasReplayStartTime { get { return HasComponent(GameComponentsLookup.ReplayStartTime); } }

    public void AddReplayStartTime(double newValue) {
        var index = GameComponentsLookup.ReplayStartTime;
        var component = (ReplayStartTimeComponent)CreateComponent(index, typeof(ReplayStartTimeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceReplayStartTime(double newValue) {
        var index = GameComponentsLookup.ReplayStartTime;
        var component = (ReplayStartTimeComponent)CreateComponent(index, typeof(ReplayStartTimeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveReplayStartTime() {
        RemoveComponent(GameComponentsLookup.ReplayStartTime);
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

    static Entitas.IMatcher<GameEntity> _matcherReplayStartTime;

    public static Entitas.IMatcher<GameEntity> ReplayStartTime {
        get {
            if (_matcherReplayStartTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReplayStartTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReplayStartTime = matcher;
            }

            return _matcherReplayStartTime;
        }
    }
}
