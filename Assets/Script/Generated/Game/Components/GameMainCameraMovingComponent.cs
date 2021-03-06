//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity mainCameraMovingEntity { get { return GetGroup(GameMatcher.MainCameraMoving).GetSingleEntity(); } }

    public bool isMainCameraMoving {
        get { return mainCameraMovingEntity != null; }
        set {
            var entity = mainCameraMovingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isMainCameraMoving = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly MainCameraMovingComponent mainCameraMovingComponent = new MainCameraMovingComponent();

    public bool isMainCameraMoving {
        get { return HasComponent(GameComponentsLookup.MainCameraMoving); }
        set {
            if (value != isMainCameraMoving) {
                var index = GameComponentsLookup.MainCameraMoving;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mainCameraMovingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherMainCameraMoving;

    public static Entitas.IMatcher<GameEntity> MainCameraMoving {
        get {
            if (_matcherMainCameraMoving == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MainCameraMoving);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMainCameraMoving = matcher;
            }

            return _matcherMainCameraMoving;
        }
    }
}
