//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity startReplayEntity { get { return GetGroup(GameMatcher.StartReplay).GetSingleEntity(); } }
    public StartReplayComponent startReplay { get { return startReplayEntity.startReplay; } }
    public bool hasStartReplay { get { return startReplayEntity != null; } }

    public GameEntity SetStartReplay(SCMatchData newMatchData) {
        if (hasStartReplay) {
            throw new Entitas.EntitasException("Could not set StartReplay!\n" + this + " already has an entity with StartReplayComponent!",
                "You should check if the context already has a startReplayEntity before setting it or use context.ReplaceStartReplay().");
        }
        var entity = CreateEntity();
        entity.AddStartReplay(newMatchData);
        return entity;
    }

    public void ReplaceStartReplay(SCMatchData newMatchData) {
        var entity = startReplayEntity;
        if (entity == null) {
            entity = SetStartReplay(newMatchData);
        } else {
            entity.ReplaceStartReplay(newMatchData);
        }
    }

    public void RemoveStartReplay() {
        startReplayEntity.Destroy();
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

    public StartReplayComponent startReplay { get { return (StartReplayComponent)GetComponent(GameComponentsLookup.StartReplay); } }
    public bool hasStartReplay { get { return HasComponent(GameComponentsLookup.StartReplay); } }

    public void AddStartReplay(SCMatchData newMatchData) {
        var index = GameComponentsLookup.StartReplay;
        var component = (StartReplayComponent)CreateComponent(index, typeof(StartReplayComponent));
        component.matchData = newMatchData;
        AddComponent(index, component);
    }

    public void ReplaceStartReplay(SCMatchData newMatchData) {
        var index = GameComponentsLookup.StartReplay;
        var component = (StartReplayComponent)CreateComponent(index, typeof(StartReplayComponent));
        component.matchData = newMatchData;
        ReplaceComponent(index, component);
    }

    public void RemoveStartReplay() {
        RemoveComponent(GameComponentsLookup.StartReplay);
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

    static Entitas.IMatcher<GameEntity> _matcherStartReplay;

    public static Entitas.IMatcher<GameEntity> StartReplay {
        get {
            if (_matcherStartReplay == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StartReplay);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStartReplay = matcher;
            }

            return _matcherStartReplay;
        }
    }
}
