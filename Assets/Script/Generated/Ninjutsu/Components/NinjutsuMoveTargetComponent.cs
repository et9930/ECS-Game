//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class NinjutsuEntity {

    public MoveTargetComponent moveTarget { get { return (MoveTargetComponent)GetComponent(NinjutsuComponentsLookup.MoveTarget); } }
    public bool hasMoveTarget { get { return HasComponent(NinjutsuComponentsLookup.MoveTarget); } }

    public void AddMoveTarget(UnityEngine.Vector2 newValue) {
        var index = NinjutsuComponentsLookup.MoveTarget;
        var component = (MoveTargetComponent)CreateComponent(index, typeof(MoveTargetComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMoveTarget(UnityEngine.Vector2 newValue) {
        var index = NinjutsuComponentsLookup.MoveTarget;
        var component = (MoveTargetComponent)CreateComponent(index, typeof(MoveTargetComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMoveTarget() {
        RemoveComponent(NinjutsuComponentsLookup.MoveTarget);
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
public partial class NinjutsuEntity : IMoveTargetEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class NinjutsuMatcher {

    static Entitas.IMatcher<NinjutsuEntity> _matcherMoveTarget;

    public static Entitas.IMatcher<NinjutsuEntity> MoveTarget {
        get {
            if (_matcherMoveTarget == null) {
                var matcher = (Entitas.Matcher<NinjutsuEntity>)Entitas.Matcher<NinjutsuEntity>.AllOf(NinjutsuComponentsLookup.MoveTarget);
                matcher.componentNames = NinjutsuComponentsLookup.componentNames;
                _matcherMoveTarget = matcher;
            }

            return _matcherMoveTarget;
        }
    }
}
