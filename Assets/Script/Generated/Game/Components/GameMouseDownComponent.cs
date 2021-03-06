//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MouseDownComponent mouseDown { get { return (MouseDownComponent)GetComponent(GameComponentsLookup.MouseDown); } }
    public bool hasMouseDown { get { return HasComponent(GameComponentsLookup.MouseDown); } }

    public void AddMouseDown(System.Numerics.Vector2 newPosition) {
        var index = GameComponentsLookup.MouseDown;
        var component = (MouseDownComponent)CreateComponent(index, typeof(MouseDownComponent));
        component.position = newPosition;
        AddComponent(index, component);
    }

    public void ReplaceMouseDown(System.Numerics.Vector2 newPosition) {
        var index = GameComponentsLookup.MouseDown;
        var component = (MouseDownComponent)CreateComponent(index, typeof(MouseDownComponent));
        component.position = newPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveMouseDown() {
        RemoveComponent(GameComponentsLookup.MouseDown);
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

    static Entitas.IMatcher<GameEntity> _matcherMouseDown;

    public static Entitas.IMatcher<GameEntity> MouseDown {
        get {
            if (_matcherMouseDown == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MouseDown);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMouseDown = matcher;
            }

            return _matcherMouseDown;
        }
    }
}
