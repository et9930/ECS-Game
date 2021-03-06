//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MakingYinComponent makingYinComponent = new MakingYinComponent();

    public bool isMakingYin {
        get { return HasComponent(GameComponentsLookup.MakingYin); }
        set {
            if (value != isMakingYin) {
                var index = GameComponentsLookup.MakingYin;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : makingYinComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherMakingYin;

    public static Entitas.IMatcher<GameEntity> MakingYin {
        get {
            if (_matcherMakingYin == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MakingYin);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMakingYin = matcher;
            }

            return _matcherMakingYin;
        }
    }
}
