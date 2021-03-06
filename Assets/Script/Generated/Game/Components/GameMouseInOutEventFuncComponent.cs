//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity mouseInOutEventFuncEntity { get { return GetGroup(GameMatcher.MouseInOutEventFunc).GetSingleEntity(); } }
    public MouseInOutEventFuncComponent mouseInOutEventFunc { get { return mouseInOutEventFuncEntity.mouseInOutEventFunc; } }
    public bool hasMouseInOutEventFunc { get { return mouseInOutEventFuncEntity != null; } }

    public GameEntity SetMouseInOutEventFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newInDic, System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newOutDic) {
        if (hasMouseInOutEventFunc) {
            throw new Entitas.EntitasException("Could not set MouseInOutEventFunc!\n" + this + " already has an entity with MouseInOutEventFuncComponent!",
                "You should check if the context already has a mouseInOutEventFuncEntity before setting it or use context.ReplaceMouseInOutEventFunc().");
        }
        var entity = CreateEntity();
        entity.AddMouseInOutEventFunc(newInDic, newOutDic);
        return entity;
    }

    public void ReplaceMouseInOutEventFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newInDic, System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newOutDic) {
        var entity = mouseInOutEventFuncEntity;
        if (entity == null) {
            entity = SetMouseInOutEventFunc(newInDic, newOutDic);
        } else {
            entity.ReplaceMouseInOutEventFunc(newInDic, newOutDic);
        }
    }

    public void RemoveMouseInOutEventFunc() {
        mouseInOutEventFuncEntity.Destroy();
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

    public MouseInOutEventFuncComponent mouseInOutEventFunc { get { return (MouseInOutEventFuncComponent)GetComponent(GameComponentsLookup.MouseInOutEventFunc); } }
    public bool hasMouseInOutEventFunc { get { return HasComponent(GameComponentsLookup.MouseInOutEventFunc); } }

    public void AddMouseInOutEventFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newInDic, System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newOutDic) {
        var index = GameComponentsLookup.MouseInOutEventFunc;
        var component = (MouseInOutEventFuncComponent)CreateComponent(index, typeof(MouseInOutEventFuncComponent));
        component.inDic = newInDic;
        component.outDic = newOutDic;
        AddComponent(index, component);
    }

    public void ReplaceMouseInOutEventFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newInDic, System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newOutDic) {
        var index = GameComponentsLookup.MouseInOutEventFunc;
        var component = (MouseInOutEventFuncComponent)CreateComponent(index, typeof(MouseInOutEventFuncComponent));
        component.inDic = newInDic;
        component.outDic = newOutDic;
        ReplaceComponent(index, component);
    }

    public void RemoveMouseInOutEventFunc() {
        RemoveComponent(GameComponentsLookup.MouseInOutEventFunc);
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

    static Entitas.IMatcher<GameEntity> _matcherMouseInOutEventFunc;

    public static Entitas.IMatcher<GameEntity> MouseInOutEventFunc {
        get {
            if (_matcherMouseInOutEventFunc == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MouseInOutEventFunc);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMouseInOutEventFunc = matcher;
            }

            return _matcherMouseInOutEventFunc;
        }
    }
}
