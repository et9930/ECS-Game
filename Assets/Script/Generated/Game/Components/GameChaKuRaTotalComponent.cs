//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ChaKuRaTotalComponent chaKuRaTotal { get { return (ChaKuRaTotalComponent)GetComponent(GameComponentsLookup.ChaKuRaTotal); } }
    public bool hasChaKuRaTotal { get { return HasComponent(GameComponentsLookup.ChaKuRaTotal); } }

    public void AddChaKuRaTotal(float newValue) {
        var index = GameComponentsLookup.ChaKuRaTotal;
        var component = (ChaKuRaTotalComponent)CreateComponent(index, typeof(ChaKuRaTotalComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceChaKuRaTotal(float newValue) {
        var index = GameComponentsLookup.ChaKuRaTotal;
        var component = (ChaKuRaTotalComponent)CreateComponent(index, typeof(ChaKuRaTotalComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveChaKuRaTotal() {
        RemoveComponent(GameComponentsLookup.ChaKuRaTotal);
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

    static Entitas.IMatcher<GameEntity> _matcherChaKuRaTotal;

    public static Entitas.IMatcher<GameEntity> ChaKuRaTotal {
        get {
            if (_matcherChaKuRaTotal == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ChaKuRaTotal);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherChaKuRaTotal = matcher;
            }

            return _matcherChaKuRaTotal;
        }
    }
}