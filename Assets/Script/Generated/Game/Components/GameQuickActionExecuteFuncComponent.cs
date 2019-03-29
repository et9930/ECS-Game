//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity quickActionExecuteFuncEntity { get { return GetGroup(GameMatcher.QuickActionExecuteFunc).GetSingleEntity(); } }
    public QuickActionExecuteFuncComponent quickActionExecuteFunc { get { return quickActionExecuteFuncEntity.quickActionExecuteFunc; } }
    public bool hasQuickActionExecuteFunc { get { return quickActionExecuteFuncEntity != null; } }

    public GameEntity SetQuickActionExecuteFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newDic) {
        if (hasQuickActionExecuteFunc) {
            throw new Entitas.EntitasException("Could not set QuickActionExecuteFunc!\n" + this + " already has an entity with QuickActionExecuteFuncComponent!",
                "You should check if the context already has a quickActionExecuteFuncEntity before setting it or use context.ReplaceQuickActionExecuteFunc().");
        }
        var entity = CreateEntity();
        entity.AddQuickActionExecuteFunc(newDic);
        return entity;
    }

    public void ReplaceQuickActionExecuteFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newDic) {
        var entity = quickActionExecuteFuncEntity;
        if (entity == null) {
            entity = SetQuickActionExecuteFunc(newDic);
        } else {
            entity.ReplaceQuickActionExecuteFunc(newDic);
        }
    }

    public void RemoveQuickActionExecuteFunc() {
        quickActionExecuteFuncEntity.Destroy();
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

    public QuickActionExecuteFuncComponent quickActionExecuteFunc { get { return (QuickActionExecuteFuncComponent)GetComponent(GameComponentsLookup.QuickActionExecuteFunc); } }
    public bool hasQuickActionExecuteFunc { get { return HasComponent(GameComponentsLookup.QuickActionExecuteFunc); } }

    public void AddQuickActionExecuteFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newDic) {
        var index = GameComponentsLookup.QuickActionExecuteFunc;
        var component = (QuickActionExecuteFuncComponent)CreateComponent(index, typeof(QuickActionExecuteFuncComponent));
        component.dic = newDic;
        AddComponent(index, component);
    }

    public void ReplaceQuickActionExecuteFunc(System.Collections.Generic.Dictionary<string, System.Action<GameEntity>> newDic) {
        var index = GameComponentsLookup.QuickActionExecuteFunc;
        var component = (QuickActionExecuteFuncComponent)CreateComponent(index, typeof(QuickActionExecuteFuncComponent));
        component.dic = newDic;
        ReplaceComponent(index, component);
    }

    public void RemoveQuickActionExecuteFunc() {
        RemoveComponent(GameComponentsLookup.QuickActionExecuteFunc);
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

    static Entitas.IMatcher<GameEntity> _matcherQuickActionExecuteFunc;

    public static Entitas.IMatcher<GameEntity> QuickActionExecuteFunc {
        get {
            if (_matcherQuickActionExecuteFunc == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.QuickActionExecuteFunc);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherQuickActionExecuteFunc = matcher;
            }

            return _matcherQuickActionExecuteFunc;
        }
    }
}