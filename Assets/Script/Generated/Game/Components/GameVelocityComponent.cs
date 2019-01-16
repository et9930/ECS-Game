//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public VelocityComponent velocity { get { return (VelocityComponent)GetComponent(GameComponentsLookup.Velocity); } }
    public bool hasVelocity { get { return HasComponent(GameComponentsLookup.Velocity); } }

    public void AddVelocity(System.Numerics.Vector3 newValue) {
        var index = GameComponentsLookup.Velocity;
        var component = (VelocityComponent)CreateComponent(index, typeof(VelocityComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceVelocity(System.Numerics.Vector3 newValue) {
        var index = GameComponentsLookup.Velocity;
        var component = (VelocityComponent)CreateComponent(index, typeof(VelocityComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveVelocity() {
        RemoveComponent(GameComponentsLookup.Velocity);
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

    static Entitas.IMatcher<GameEntity> _matcherVelocity;

    public static Entitas.IMatcher<GameEntity> Velocity {
        get {
            if (_matcherVelocity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Velocity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocity = matcher;
            }

            return _matcherVelocity;
        }
    }
}
