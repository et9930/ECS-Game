//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MouseUpComponent mouseUp { get { return (MouseUpComponent)GetComponent(GameComponentsLookup.MouseUp); } }
    public bool hasMouseUp { get { return HasComponent(GameComponentsLookup.MouseUp); } }

    public void AddMouseUp(System.Numerics.Vector2 newPosition) {
        var index = GameComponentsLookup.MouseUp;
        var component = (MouseUpComponent)CreateComponent(index, typeof(MouseUpComponent));
        component.position = newPosition;
        AddComponent(index, component);
    }

    public void ReplaceMouseUp(System.Numerics.Vector2 newPosition) {
        var index = GameComponentsLookup.MouseUp;
        var component = (MouseUpComponent)CreateComponent(index, typeof(MouseUpComponent));
        component.position = newPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveMouseUp() {
        RemoveComponent(GameComponentsLookup.MouseUp);
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

    static Entitas.IMatcher<GameEntity> _matcherMouseUp;

    public static Entitas.IMatcher<GameEntity> MouseUp {
        get {
            if (_matcherMouseUp == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MouseUp);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMouseUp = matcher;
            }

            return _matcherMouseUp;
        }
    }
}
