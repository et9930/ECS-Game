//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public JutsuTargetComponent jutsuTarget { get { return (JutsuTargetComponent)GetComponent(GameComponentsLookup.JutsuTarget); } }
    public bool hasJutsuTarget { get { return HasComponent(GameComponentsLookup.JutsuTarget); } }

    public void AddJutsuTarget(GameEntity newValue) {
        var index = GameComponentsLookup.JutsuTarget;
        var component = (JutsuTargetComponent)CreateComponent(index, typeof(JutsuTargetComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceJutsuTarget(GameEntity newValue) {
        var index = GameComponentsLookup.JutsuTarget;
        var component = (JutsuTargetComponent)CreateComponent(index, typeof(JutsuTargetComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveJutsuTarget() {
        RemoveComponent(GameComponentsLookup.JutsuTarget);
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

    static Entitas.IMatcher<GameEntity> _matcherJutsuTarget;

    public static Entitas.IMatcher<GameEntity> JutsuTarget {
        get {
            if (_matcherJutsuTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JutsuTarget);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJutsuTarget = matcher;
            }

            return _matcherJutsuTarget;
        }
    }
}
