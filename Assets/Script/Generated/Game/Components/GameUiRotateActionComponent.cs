//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UiRotateActionComponent uiRotateAction { get { return (UiRotateActionComponent)GetComponent(GameComponentsLookup.UiRotateAction); } }
    public bool hasUiRotateAction { get { return HasComponent(GameComponentsLookup.UiRotateAction); } }

    public void AddUiRotateAction(string newUiName, float newRotateAngle, float newRotateDuration) {
        var index = GameComponentsLookup.UiRotateAction;
        var component = (UiRotateActionComponent)CreateComponent(index, typeof(UiRotateActionComponent));
        component.uiName = newUiName;
        component.rotateAngle = newRotateAngle;
        component.rotateDuration = newRotateDuration;
        AddComponent(index, component);
    }

    public void ReplaceUiRotateAction(string newUiName, float newRotateAngle, float newRotateDuration) {
        var index = GameComponentsLookup.UiRotateAction;
        var component = (UiRotateActionComponent)CreateComponent(index, typeof(UiRotateActionComponent));
        component.uiName = newUiName;
        component.rotateAngle = newRotateAngle;
        component.rotateDuration = newRotateDuration;
        ReplaceComponent(index, component);
    }

    public void RemoveUiRotateAction() {
        RemoveComponent(GameComponentsLookup.UiRotateAction);
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

    static Entitas.IMatcher<GameEntity> _matcherUiRotateAction;

    public static Entitas.IMatcher<GameEntity> UiRotateAction {
        get {
            if (_matcherUiRotateAction == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UiRotateAction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUiRotateAction = matcher;
            }

            return _matcherUiRotateAction;
        }
    }
}
