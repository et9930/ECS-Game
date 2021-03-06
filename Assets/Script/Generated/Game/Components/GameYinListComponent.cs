//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public YinListComponent yinList { get { return (YinListComponent)GetComponent(GameComponentsLookup.YinList); } }
    public bool hasYinList { get { return HasComponent(GameComponentsLookup.YinList); } }

    public void AddYinList(System.Collections.Generic.List<Yin> newList) {
        var index = GameComponentsLookup.YinList;
        var component = (YinListComponent)CreateComponent(index, typeof(YinListComponent));
        component.list = newList;
        AddComponent(index, component);
    }

    public void ReplaceYinList(System.Collections.Generic.List<Yin> newList) {
        var index = GameComponentsLookup.YinList;
        var component = (YinListComponent)CreateComponent(index, typeof(YinListComponent));
        component.list = newList;
        ReplaceComponent(index, component);
    }

    public void RemoveYinList() {
        RemoveComponent(GameComponentsLookup.YinList);
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

    static Entitas.IMatcher<GameEntity> _matcherYinList;

    public static Entitas.IMatcher<GameEntity> YinList {
        get {
            if (_matcherYinList == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.YinList);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherYinList = matcher;
            }

            return _matcherYinList;
        }
    }
}
