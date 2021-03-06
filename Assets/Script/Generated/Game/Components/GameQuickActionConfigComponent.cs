//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity quickActionConfigEntity { get { return GetGroup(GameMatcher.QuickActionConfig).GetSingleEntity(); } }
    public QuickActionConfigComponent quickActionConfig { get { return quickActionConfigEntity.quickActionConfig; } }
    public bool hasQuickActionConfig { get { return quickActionConfigEntity != null; } }

    public GameEntity SetQuickActionConfig(System.Collections.Generic.List<QuickAction> newList) {
        if (hasQuickActionConfig) {
            throw new Entitas.EntitasException("Could not set QuickActionConfig!\n" + this + " already has an entity with QuickActionConfigComponent!",
                "You should check if the context already has a quickActionConfigEntity before setting it or use context.ReplaceQuickActionConfig().");
        }
        var entity = CreateEntity();
        entity.AddQuickActionConfig(newList);
        return entity;
    }

    public void ReplaceQuickActionConfig(System.Collections.Generic.List<QuickAction> newList) {
        var entity = quickActionConfigEntity;
        if (entity == null) {
            entity = SetQuickActionConfig(newList);
        } else {
            entity.ReplaceQuickActionConfig(newList);
        }
    }

    public void RemoveQuickActionConfig() {
        quickActionConfigEntity.Destroy();
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

    public QuickActionConfigComponent quickActionConfig { get { return (QuickActionConfigComponent)GetComponent(GameComponentsLookup.QuickActionConfig); } }
    public bool hasQuickActionConfig { get { return HasComponent(GameComponentsLookup.QuickActionConfig); } }

    public void AddQuickActionConfig(System.Collections.Generic.List<QuickAction> newList) {
        var index = GameComponentsLookup.QuickActionConfig;
        var component = (QuickActionConfigComponent)CreateComponent(index, typeof(QuickActionConfigComponent));
        component.list = newList;
        AddComponent(index, component);
    }

    public void ReplaceQuickActionConfig(System.Collections.Generic.List<QuickAction> newList) {
        var index = GameComponentsLookup.QuickActionConfig;
        var component = (QuickActionConfigComponent)CreateComponent(index, typeof(QuickActionConfigComponent));
        component.list = newList;
        ReplaceComponent(index, component);
    }

    public void RemoveQuickActionConfig() {
        RemoveComponent(GameComponentsLookup.QuickActionConfig);
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

    static Entitas.IMatcher<GameEntity> _matcherQuickActionConfig;

    public static Entitas.IMatcher<GameEntity> QuickActionConfig {
        get {
            if (_matcherQuickActionConfig == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.QuickActionConfig);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherQuickActionConfig = matcher;
            }

            return _matcherQuickActionConfig;
        }
    }
}
