//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ChaKuRaCurrentComponent chaKuRaCurrent { get { return (ChaKuRaCurrentComponent)GetComponent(GameComponentsLookup.ChaKuRaCurrent); } }
    public bool hasChaKuRaCurrent { get { return HasComponent(GameComponentsLookup.ChaKuRaCurrent); } }

    public void AddChaKuRaCurrent(float newValue) {
        var index = GameComponentsLookup.ChaKuRaCurrent;
        var component = (ChaKuRaCurrentComponent)CreateComponent(index, typeof(ChaKuRaCurrentComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceChaKuRaCurrent(float newValue) {
        var index = GameComponentsLookup.ChaKuRaCurrent;
        var component = (ChaKuRaCurrentComponent)CreateComponent(index, typeof(ChaKuRaCurrentComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveChaKuRaCurrent() {
        RemoveComponent(GameComponentsLookup.ChaKuRaCurrent);
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

    static Entitas.IMatcher<GameEntity> _matcherChaKuRaCurrent;

    public static Entitas.IMatcher<GameEntity> ChaKuRaCurrent {
        get {
            if (_matcherChaKuRaCurrent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ChaKuRaCurrent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherChaKuRaCurrent = matcher;
            }

            return _matcherChaKuRaCurrent;
        }
    }
}
