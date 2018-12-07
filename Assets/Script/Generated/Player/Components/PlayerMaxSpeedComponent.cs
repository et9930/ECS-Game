//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity {

    public MaxSpeedComponent maxSpeed { get { return (MaxSpeedComponent)GetComponent(PlayerComponentsLookup.MaxSpeed); } }
    public bool hasMaxSpeed { get { return HasComponent(PlayerComponentsLookup.MaxSpeed); } }

    public void AddMaxSpeed(int newValue) {
        var index = PlayerComponentsLookup.MaxSpeed;
        var component = (MaxSpeedComponent)CreateComponent(index, typeof(MaxSpeedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMaxSpeed(int newValue) {
        var index = PlayerComponentsLookup.MaxSpeed;
        var component = (MaxSpeedComponent)CreateComponent(index, typeof(MaxSpeedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMaxSpeed() {
        RemoveComponent(PlayerComponentsLookup.MaxSpeed);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class PlayerEntity : IMaxSpeedEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class PlayerMatcher {

    static Entitas.IMatcher<PlayerEntity> _matcherMaxSpeed;

    public static Entitas.IMatcher<PlayerEntity> MaxSpeed {
        get {
            if (_matcherMaxSpeed == null) {
                var matcher = (Entitas.Matcher<PlayerEntity>)Entitas.Matcher<PlayerEntity>.AllOf(PlayerComponentsLookup.MaxSpeed);
                matcher.componentNames = PlayerComponentsLookup.componentNames;
                _matcherMaxSpeed = matcher;
            }

            return _matcherMaxSpeed;
        }
    }
}