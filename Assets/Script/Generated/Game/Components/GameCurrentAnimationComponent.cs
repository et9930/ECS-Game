//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CurrentAnimationComponent currentAnimation { get { return (CurrentAnimationComponent)GetComponent(GameComponentsLookup.CurrentAnimation); } }
    public bool hasCurrentAnimation { get { return HasComponent(GameComponentsLookup.CurrentAnimation); } }

    public void AddCurrentAnimation(string newName) {
        var index = GameComponentsLookup.CurrentAnimation;
        var component = (CurrentAnimationComponent)CreateComponent(index, typeof(CurrentAnimationComponent));
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplaceCurrentAnimation(string newName) {
        var index = GameComponentsLookup.CurrentAnimation;
        var component = (CurrentAnimationComponent)CreateComponent(index, typeof(CurrentAnimationComponent));
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentAnimation() {
        RemoveComponent(GameComponentsLookup.CurrentAnimation);
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentAnimation;

    public static Entitas.IMatcher<GameEntity> CurrentAnimation {
        get {
            if (_matcherCurrentAnimation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentAnimation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentAnimation = matcher;
            }

            return _matcherCurrentAnimation;
        }
    }
}
