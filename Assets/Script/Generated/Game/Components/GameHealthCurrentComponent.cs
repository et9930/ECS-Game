//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HealthCurrentComponent healthCurrent { get { return (HealthCurrentComponent)GetComponent(GameComponentsLookup.HealthCurrent); } }
    public bool hasHealthCurrent { get { return HasComponent(GameComponentsLookup.HealthCurrent); } }

    public void AddHealthCurrent(float newValue) {
        var index = GameComponentsLookup.HealthCurrent;
        var component = (HealthCurrentComponent)CreateComponent(index, typeof(HealthCurrentComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHealthCurrent(float newValue) {
        var index = GameComponentsLookup.HealthCurrent;
        var component = (HealthCurrentComponent)CreateComponent(index, typeof(HealthCurrentComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHealthCurrent() {
        RemoveComponent(GameComponentsLookup.HealthCurrent);
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

    static Entitas.IMatcher<GameEntity> _matcherHealthCurrent;

    public static Entitas.IMatcher<GameEntity> HealthCurrent {
        get {
            if (_matcherHealthCurrent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HealthCurrent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHealthCurrent = matcher;
            }

            return _matcherHealthCurrent;
        }
    }
}
