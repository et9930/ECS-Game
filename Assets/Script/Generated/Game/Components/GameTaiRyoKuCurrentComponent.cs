//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TaiRyoKuCurrentComponent taiRyoKuCurrent { get { return (TaiRyoKuCurrentComponent)GetComponent(GameComponentsLookup.TaiRyoKuCurrent); } }
    public bool hasTaiRyoKuCurrent { get { return HasComponent(GameComponentsLookup.TaiRyoKuCurrent); } }

    public void AddTaiRyoKuCurrent(float newValue) {
        var index = GameComponentsLookup.TaiRyoKuCurrent;
        var component = (TaiRyoKuCurrentComponent)CreateComponent(index, typeof(TaiRyoKuCurrentComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTaiRyoKuCurrent(float newValue) {
        var index = GameComponentsLookup.TaiRyoKuCurrent;
        var component = (TaiRyoKuCurrentComponent)CreateComponent(index, typeof(TaiRyoKuCurrentComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTaiRyoKuCurrent() {
        RemoveComponent(GameComponentsLookup.TaiRyoKuCurrent);
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

    static Entitas.IMatcher<GameEntity> _matcherTaiRyoKuCurrent;

    public static Entitas.IMatcher<GameEntity> TaiRyoKuCurrent {
        get {
            if (_matcherTaiRyoKuCurrent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TaiRyoKuCurrent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTaiRyoKuCurrent = matcher;
            }

            return _matcherTaiRyoKuCurrent;
        }
    }
}
