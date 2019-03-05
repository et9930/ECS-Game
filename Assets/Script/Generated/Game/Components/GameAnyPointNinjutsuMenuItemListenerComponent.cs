//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyPointNinjutsuMenuItemListenerComponent anyPointNinjutsuMenuItemListener { get { return (AnyPointNinjutsuMenuItemListenerComponent)GetComponent(GameComponentsLookup.AnyPointNinjutsuMenuItemListener); } }
    public bool hasAnyPointNinjutsuMenuItemListener { get { return HasComponent(GameComponentsLookup.AnyPointNinjutsuMenuItemListener); } }

    public void AddAnyPointNinjutsuMenuItemListener(System.Collections.Generic.List<IAnyPointNinjutsuMenuItemListener> newValue) {
        var index = GameComponentsLookup.AnyPointNinjutsuMenuItemListener;
        var component = (AnyPointNinjutsuMenuItemListenerComponent)CreateComponent(index, typeof(AnyPointNinjutsuMenuItemListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyPointNinjutsuMenuItemListener(System.Collections.Generic.List<IAnyPointNinjutsuMenuItemListener> newValue) {
        var index = GameComponentsLookup.AnyPointNinjutsuMenuItemListener;
        var component = (AnyPointNinjutsuMenuItemListenerComponent)CreateComponent(index, typeof(AnyPointNinjutsuMenuItemListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyPointNinjutsuMenuItemListener() {
        RemoveComponent(GameComponentsLookup.AnyPointNinjutsuMenuItemListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyPointNinjutsuMenuItemListener;

    public static Entitas.IMatcher<GameEntity> AnyPointNinjutsuMenuItemListener {
        get {
            if (_matcherAnyPointNinjutsuMenuItemListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyPointNinjutsuMenuItemListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyPointNinjutsuMenuItemListener = matcher;
            }

            return _matcherAnyPointNinjutsuMenuItemListener;
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

    public void AddAnyPointNinjutsuMenuItemListener(IAnyPointNinjutsuMenuItemListener value) {
        var listeners = hasAnyPointNinjutsuMenuItemListener
            ? anyPointNinjutsuMenuItemListener.value
            : new System.Collections.Generic.List<IAnyPointNinjutsuMenuItemListener>();
        listeners.Add(value);
        ReplaceAnyPointNinjutsuMenuItemListener(listeners);
    }

    public void RemoveAnyPointNinjutsuMenuItemListener(IAnyPointNinjutsuMenuItemListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyPointNinjutsuMenuItemListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyPointNinjutsuMenuItemListener();
        } else {
            ReplaceAnyPointNinjutsuMenuItemListener(listeners);
        }
    }
}