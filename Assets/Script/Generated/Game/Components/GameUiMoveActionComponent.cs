//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UiMoveActionComponent uiMoveAction { get { return (UiMoveActionComponent)GetComponent(GameComponentsLookup.UiMoveAction); } }
    public bool hasUiMoveAction { get { return HasComponent(GameComponentsLookup.UiMoveAction); } }

    public void AddUiMoveAction(string newUiName, bool newMoveFor, System.Numerics.Vector2 newMoveLocation, float newMoveDuration) {
        var index = GameComponentsLookup.UiMoveAction;
        var component = (UiMoveActionComponent)CreateComponent(index, typeof(UiMoveActionComponent));
        component.uiName = newUiName;
        component.moveFor = newMoveFor;
        component.moveLocation = newMoveLocation;
        component.moveDuration = newMoveDuration;
        AddComponent(index, component);
    }

    public void ReplaceUiMoveAction(string newUiName, bool newMoveFor, System.Numerics.Vector2 newMoveLocation, float newMoveDuration) {
        var index = GameComponentsLookup.UiMoveAction;
        var component = (UiMoveActionComponent)CreateComponent(index, typeof(UiMoveActionComponent));
        component.uiName = newUiName;
        component.moveFor = newMoveFor;
        component.moveLocation = newMoveLocation;
        component.moveDuration = newMoveDuration;
        ReplaceComponent(index, component);
    }

    public void RemoveUiMoveAction() {
        RemoveComponent(GameComponentsLookup.UiMoveAction);
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

    static Entitas.IMatcher<GameEntity> _matcherUiMoveAction;

    public static Entitas.IMatcher<GameEntity> UiMoveAction {
        get {
            if (_matcherUiMoveAction == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UiMoveAction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUiMoveAction = matcher;
            }

            return _matcherUiMoveAction;
        }
    }
}
