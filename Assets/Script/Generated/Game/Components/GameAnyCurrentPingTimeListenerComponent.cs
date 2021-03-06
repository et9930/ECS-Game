//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyCurrentPingTimeListenerComponent anyCurrentPingTimeListener { get { return (AnyCurrentPingTimeListenerComponent)GetComponent(GameComponentsLookup.AnyCurrentPingTimeListener); } }
    public bool hasAnyCurrentPingTimeListener { get { return HasComponent(GameComponentsLookup.AnyCurrentPingTimeListener); } }

    public void AddAnyCurrentPingTimeListener(System.Collections.Generic.List<IAnyCurrentPingTimeListener> newValue) {
        var index = GameComponentsLookup.AnyCurrentPingTimeListener;
        var component = (AnyCurrentPingTimeListenerComponent)CreateComponent(index, typeof(AnyCurrentPingTimeListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyCurrentPingTimeListener(System.Collections.Generic.List<IAnyCurrentPingTimeListener> newValue) {
        var index = GameComponentsLookup.AnyCurrentPingTimeListener;
        var component = (AnyCurrentPingTimeListenerComponent)CreateComponent(index, typeof(AnyCurrentPingTimeListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyCurrentPingTimeListener() {
        RemoveComponent(GameComponentsLookup.AnyCurrentPingTimeListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyCurrentPingTimeListener;

    public static Entitas.IMatcher<GameEntity> AnyCurrentPingTimeListener {
        get {
            if (_matcherAnyCurrentPingTimeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyCurrentPingTimeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyCurrentPingTimeListener = matcher;
            }

            return _matcherAnyCurrentPingTimeListener;
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

    public void AddAnyCurrentPingTimeListener(IAnyCurrentPingTimeListener value) {
        var listeners = hasAnyCurrentPingTimeListener
            ? anyCurrentPingTimeListener.value
            : new System.Collections.Generic.List<IAnyCurrentPingTimeListener>();
        listeners.Add(value);
        ReplaceAnyCurrentPingTimeListener(listeners);
    }

    public void RemoveAnyCurrentPingTimeListener(IAnyCurrentPingTimeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyCurrentPingTimeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyCurrentPingTimeListener();
        } else {
            ReplaceAnyCurrentPingTimeListener(listeners);
        }
    }
}
