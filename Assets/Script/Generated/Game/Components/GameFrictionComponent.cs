//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FrictionComponent friction { get { return (FrictionComponent)GetComponent(GameComponentsLookup.Friction); } }
    public bool hasFriction { get { return HasComponent(GameComponentsLookup.Friction); } }

    public void AddFriction(float newValue) {
        var index = GameComponentsLookup.Friction;
        var component = (FrictionComponent)CreateComponent(index, typeof(FrictionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFriction(float newValue) {
        var index = GameComponentsLookup.Friction;
        var component = (FrictionComponent)CreateComponent(index, typeof(FrictionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFriction() {
        RemoveComponent(GameComponentsLookup.Friction);
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

    static Entitas.IMatcher<GameEntity> _matcherFriction;

    public static Entitas.IMatcher<GameEntity> Friction {
        get {
            if (_matcherFriction == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Friction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFriction = matcher;
            }

            return _matcherFriction;
        }
    }
}