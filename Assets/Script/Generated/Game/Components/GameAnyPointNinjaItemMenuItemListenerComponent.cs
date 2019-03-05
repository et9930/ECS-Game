//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyPointNinjaItemMenuItemListenerComponent anyPointNinjaItemMenuItemListener { get { return (AnyPointNinjaItemMenuItemListenerComponent)GetComponent(GameComponentsLookup.AnyPointNinjaItemMenuItemListener); } }
    public bool hasAnyPointNinjaItemMenuItemListener { get { return HasComponent(GameComponentsLookup.AnyPointNinjaItemMenuItemListener); } }

    public void AddAnyPointNinjaItemMenuItemListener(System.Collections.Generic.List<IAnyPointNinjaItemMenuItemListener> newValue) {
        var index = GameComponentsLookup.AnyPointNinjaItemMenuItemListener;
        var component = (AnyPointNinjaItemMenuItemListenerComponent)CreateComponent(index, typeof(AnyPointNinjaItemMenuItemListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyPointNinjaItemMenuItemListener(System.Collections.Generic.List<IAnyPointNinjaItemMenuItemListener> newValue) {
        var index = GameComponentsLookup.AnyPointNinjaItemMenuItemListener;
        var component = (AnyPointNinjaItemMenuItemListenerComponent)CreateComponent(index, typeof(AnyPointNinjaItemMenuItemListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyPointNinjaItemMenuItemListener() {
        RemoveComponent(GameComponentsLookup.AnyPointNinjaItemMenuItemListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyPointNinjaItemMenuItemListener;

    public static Entitas.IMatcher<GameEntity> AnyPointNinjaItemMenuItemListener {
        get {
            if (_matcherAnyPointNinjaItemMenuItemListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyPointNinjaItemMenuItemListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyPointNinjaItemMenuItemListener = matcher;
            }

            return _matcherAnyPointNinjaItemMenuItemListener;
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

    public void AddAnyPointNinjaItemMenuItemListener(IAnyPointNinjaItemMenuItemListener value) {
        var listeners = hasAnyPointNinjaItemMenuItemListener
            ? anyPointNinjaItemMenuItemListener.value
            : new System.Collections.Generic.List<IAnyPointNinjaItemMenuItemListener>();
        listeners.Add(value);
        ReplaceAnyPointNinjaItemMenuItemListener(listeners);
    }

    public void RemoveAnyPointNinjaItemMenuItemListener(IAnyPointNinjaItemMenuItemListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyPointNinjaItemMenuItemListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyPointNinjaItemMenuItemListener();
        } else {
            ReplaceAnyPointNinjaItemMenuItemListener(listeners);
        }
    }
}