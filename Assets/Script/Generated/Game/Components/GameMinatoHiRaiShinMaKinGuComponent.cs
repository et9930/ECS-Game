//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MinatoHiRaiShinMaKinGuComponent minatoHiRaiShinMaKinGuComponent = new MinatoHiRaiShinMaKinGuComponent();

    public bool isMinatoHiRaiShinMaKinGu {
        get { return HasComponent(GameComponentsLookup.MinatoHiRaiShinMaKinGu); }
        set {
            if (value != isMinatoHiRaiShinMaKinGu) {
                var index = GameComponentsLookup.MinatoHiRaiShinMaKinGu;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : minatoHiRaiShinMaKinGuComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherMinatoHiRaiShinMaKinGu;

    public static Entitas.IMatcher<GameEntity> MinatoHiRaiShinMaKinGu {
        get {
            if (_matcherMinatoHiRaiShinMaKinGu == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MinatoHiRaiShinMaKinGu);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMinatoHiRaiShinMaKinGu = matcher;
            }

            return _matcherMinatoHiRaiShinMaKinGu;
        }
    }
}
