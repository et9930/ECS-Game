//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NinjaItemNameComponent ninjaItemName { get { return (NinjaItemNameComponent)GetComponent(GameComponentsLookup.NinjaItemName); } }
    public bool hasNinjaItemName { get { return HasComponent(GameComponentsLookup.NinjaItemName); } }

    public void AddNinjaItemName(string newValue) {
        var index = GameComponentsLookup.NinjaItemName;
        var component = (NinjaItemNameComponent)CreateComponent(index, typeof(NinjaItemNameComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceNinjaItemName(string newValue) {
        var index = GameComponentsLookup.NinjaItemName;
        var component = (NinjaItemNameComponent)CreateComponent(index, typeof(NinjaItemNameComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveNinjaItemName() {
        RemoveComponent(GameComponentsLookup.NinjaItemName);
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

    static Entitas.IMatcher<GameEntity> _matcherNinjaItemName;

    public static Entitas.IMatcher<GameEntity> NinjaItemName {
        get {
            if (_matcherNinjaItemName == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NinjaItemName);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNinjaItemName = matcher;
            }

            return _matcherNinjaItemName;
        }
    }
}
