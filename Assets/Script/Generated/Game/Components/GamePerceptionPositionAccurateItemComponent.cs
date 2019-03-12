//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PerceptionPositionAccurateItemComponent perceptionPositionAccurateItem { get { return (PerceptionPositionAccurateItemComponent)GetComponent(GameComponentsLookup.PerceptionPositionAccurateItem); } }
    public bool hasPerceptionPositionAccurateItem { get { return HasComponent(GameComponentsLookup.PerceptionPositionAccurateItem); } }

    public void AddPerceptionPositionAccurateItem(string newName, bool newLeft, float newY, int newDistance) {
        var index = GameComponentsLookup.PerceptionPositionAccurateItem;
        var component = (PerceptionPositionAccurateItemComponent)CreateComponent(index, typeof(PerceptionPositionAccurateItemComponent));
        component.name = newName;
        component.left = newLeft;
        component.y = newY;
        component.distance = newDistance;
        AddComponent(index, component);
    }

    public void ReplacePerceptionPositionAccurateItem(string newName, bool newLeft, float newY, int newDistance) {
        var index = GameComponentsLookup.PerceptionPositionAccurateItem;
        var component = (PerceptionPositionAccurateItemComponent)CreateComponent(index, typeof(PerceptionPositionAccurateItemComponent));
        component.name = newName;
        component.left = newLeft;
        component.y = newY;
        component.distance = newDistance;
        ReplaceComponent(index, component);
    }

    public void RemovePerceptionPositionAccurateItem() {
        RemoveComponent(GameComponentsLookup.PerceptionPositionAccurateItem);
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

    static Entitas.IMatcher<GameEntity> _matcherPerceptionPositionAccurateItem;

    public static Entitas.IMatcher<GameEntity> PerceptionPositionAccurateItem {
        get {
            if (_matcherPerceptionPositionAccurateItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PerceptionPositionAccurateItem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPerceptionPositionAccurateItem = matcher;
            }

            return _matcherPerceptionPositionAccurateItem;
        }
    }
}
