//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class NinjutsuEntity {

    public AccelerationComponent acceleration { get { return (AccelerationComponent)GetComponent(NinjutsuComponentsLookup.Acceleration); } }
    public bool hasAcceleration { get { return HasComponent(NinjutsuComponentsLookup.Acceleration); } }

    public void AddAcceleration(float newValue) {
        var index = NinjutsuComponentsLookup.Acceleration;
        var component = (AccelerationComponent)CreateComponent(index, typeof(AccelerationComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAcceleration(float newValue) {
        var index = NinjutsuComponentsLookup.Acceleration;
        var component = (AccelerationComponent)CreateComponent(index, typeof(AccelerationComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAcceleration() {
        RemoveComponent(NinjutsuComponentsLookup.Acceleration);
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
public partial class NinjutsuEntity : IAccelerationEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NinjutsuMatcher {

    static Entitas.IMatcher<NinjutsuEntity> _matcherAcceleration;

    public static Entitas.IMatcher<NinjutsuEntity> Acceleration {
        get {
            if (_matcherAcceleration == null) {
                var matcher = (Entitas.Matcher<NinjutsuEntity>)Entitas.Matcher<NinjutsuEntity>.AllOf(NinjutsuComponentsLookup.Acceleration);
                matcher.componentNames = NinjutsuComponentsLookup.componentNames;
                _matcherAcceleration = matcher;
            }

            return _matcherAcceleration;
        }
    }
}