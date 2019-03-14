//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FinalPerceptionLevelComponent finalPerceptionLevel { get { return (FinalPerceptionLevelComponent)GetComponent(GameComponentsLookup.FinalPerceptionLevel); } }
    public bool hasFinalPerceptionLevel { get { return HasComponent(GameComponentsLookup.FinalPerceptionLevel); } }

    public void AddFinalPerceptionLevel(int newValue) {
        var index = GameComponentsLookup.FinalPerceptionLevel;
        var component = (FinalPerceptionLevelComponent)CreateComponent(index, typeof(FinalPerceptionLevelComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFinalPerceptionLevel(int newValue) {
        var index = GameComponentsLookup.FinalPerceptionLevel;
        var component = (FinalPerceptionLevelComponent)CreateComponent(index, typeof(FinalPerceptionLevelComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFinalPerceptionLevel() {
        RemoveComponent(GameComponentsLookup.FinalPerceptionLevel);
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

    static Entitas.IMatcher<GameEntity> _matcherFinalPerceptionLevel;

    public static Entitas.IMatcher<GameEntity> FinalPerceptionLevel {
        get {
            if (_matcherFinalPerceptionLevel == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FinalPerceptionLevel);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFinalPerceptionLevel = matcher;
            }

            return _matcherFinalPerceptionLevel;
        }
    }
}