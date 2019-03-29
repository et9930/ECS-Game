//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public QuickActionItemConfigListenerComponent quickActionItemConfigListener { get { return (QuickActionItemConfigListenerComponent)GetComponent(GameComponentsLookup.QuickActionItemConfigListener); } }
    public bool hasQuickActionItemConfigListener { get { return HasComponent(GameComponentsLookup.QuickActionItemConfigListener); } }

    public void AddQuickActionItemConfigListener(System.Collections.Generic.List<IQuickActionItemConfigListener> newValue) {
        var index = GameComponentsLookup.QuickActionItemConfigListener;
        var component = (QuickActionItemConfigListenerComponent)CreateComponent(index, typeof(QuickActionItemConfigListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceQuickActionItemConfigListener(System.Collections.Generic.List<IQuickActionItemConfigListener> newValue) {
        var index = GameComponentsLookup.QuickActionItemConfigListener;
        var component = (QuickActionItemConfigListenerComponent)CreateComponent(index, typeof(QuickActionItemConfigListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveQuickActionItemConfigListener() {
        RemoveComponent(GameComponentsLookup.QuickActionItemConfigListener);
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

    static Entitas.IMatcher<GameEntity> _matcherQuickActionItemConfigListener;

    public static Entitas.IMatcher<GameEntity> QuickActionItemConfigListener {
        get {
            if (_matcherQuickActionItemConfigListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.QuickActionItemConfigListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherQuickActionItemConfigListener = matcher;
            }

            return _matcherQuickActionItemConfigListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddQuickActionItemConfigListener(IQuickActionItemConfigListener value) {
        var listeners = hasQuickActionItemConfigListener
            ? quickActionItemConfigListener.value
            : new System.Collections.Generic.List<IQuickActionItemConfigListener>();
        listeners.Add(value);
        ReplaceQuickActionItemConfigListener(listeners);
    }

    public void RemoveQuickActionItemConfigListener(IQuickActionItemConfigListener value, bool removeComponentWhenEmpty = true) {
        var listeners = quickActionItemConfigListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveQuickActionItemConfigListener();
        } else {
            ReplaceQuickActionItemConfigListener(listeners);
        }
    }
}