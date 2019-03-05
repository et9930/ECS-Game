//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TaiRyoKuTotalComponent taiRyoKuTotal { get { return (TaiRyoKuTotalComponent)GetComponent(GameComponentsLookup.TaiRyoKuTotal); } }
    public bool hasTaiRyoKuTotal { get { return HasComponent(GameComponentsLookup.TaiRyoKuTotal); } }

    public void AddTaiRyoKuTotal(float newValue) {
        var index = GameComponentsLookup.TaiRyoKuTotal;
        var component = (TaiRyoKuTotalComponent)CreateComponent(index, typeof(TaiRyoKuTotalComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTaiRyoKuTotal(float newValue) {
        var index = GameComponentsLookup.TaiRyoKuTotal;
        var component = (TaiRyoKuTotalComponent)CreateComponent(index, typeof(TaiRyoKuTotalComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTaiRyoKuTotal() {
        RemoveComponent(GameComponentsLookup.TaiRyoKuTotal);
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

    static Entitas.IMatcher<GameEntity> _matcherTaiRyoKuTotal;

    public static Entitas.IMatcher<GameEntity> TaiRyoKuTotal {
        get {
            if (_matcherTaiRyoKuTotal == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TaiRyoKuTotal);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTaiRyoKuTotal = matcher;
            }

            return _matcherTaiRyoKuTotal;
        }
    }
}