//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MatchDataComponent matchData { get { return (MatchDataComponent)GetComponent(GameComponentsLookup.MatchData); } }
    public bool hasMatchData { get { return HasComponent(GameComponentsLookup.MatchData); } }

    public void AddMatchData(long newDataCode, string newPayload) {
        var index = GameComponentsLookup.MatchData;
        var component = (MatchDataComponent)CreateComponent(index, typeof(MatchDataComponent));
        component.dataCode = newDataCode;
        component.payload = newPayload;
        AddComponent(index, component);
    }

    public void ReplaceMatchData(long newDataCode, string newPayload) {
        var index = GameComponentsLookup.MatchData;
        var component = (MatchDataComponent)CreateComponent(index, typeof(MatchDataComponent));
        component.dataCode = newDataCode;
        component.payload = newPayload;
        ReplaceComponent(index, component);
    }

    public void RemoveMatchData() {
        RemoveComponent(GameComponentsLookup.MatchData);
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

    static Entitas.IMatcher<GameEntity> _matcherMatchData;

    public static Entitas.IMatcher<GameEntity> MatchData {
        get {
            if (_matcherMatchData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MatchData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMatchData = matcher;
            }

            return _matcherMatchData;
        }
    }
}
