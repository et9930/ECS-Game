//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyCurrentPlayerUserDataListenerComponent anyCurrentPlayerUserDataListener { get { return (AnyCurrentPlayerUserDataListenerComponent)GetComponent(GameComponentsLookup.AnyCurrentPlayerUserDataListener); } }
    public bool hasAnyCurrentPlayerUserDataListener { get { return HasComponent(GameComponentsLookup.AnyCurrentPlayerUserDataListener); } }

    public void AddAnyCurrentPlayerUserDataListener(System.Collections.Generic.List<IAnyCurrentPlayerUserDataListener> newValue) {
        var index = GameComponentsLookup.AnyCurrentPlayerUserDataListener;
        var component = (AnyCurrentPlayerUserDataListenerComponent)CreateComponent(index, typeof(AnyCurrentPlayerUserDataListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyCurrentPlayerUserDataListener(System.Collections.Generic.List<IAnyCurrentPlayerUserDataListener> newValue) {
        var index = GameComponentsLookup.AnyCurrentPlayerUserDataListener;
        var component = (AnyCurrentPlayerUserDataListenerComponent)CreateComponent(index, typeof(AnyCurrentPlayerUserDataListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyCurrentPlayerUserDataListener() {
        RemoveComponent(GameComponentsLookup.AnyCurrentPlayerUserDataListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyCurrentPlayerUserDataListener;

    public static Entitas.IMatcher<GameEntity> AnyCurrentPlayerUserDataListener {
        get {
            if (_matcherAnyCurrentPlayerUserDataListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyCurrentPlayerUserDataListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyCurrentPlayerUserDataListener = matcher;
            }

            return _matcherAnyCurrentPlayerUserDataListener;
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

    public void AddAnyCurrentPlayerUserDataListener(IAnyCurrentPlayerUserDataListener value) {
        var listeners = hasAnyCurrentPlayerUserDataListener
            ? anyCurrentPlayerUserDataListener.value
            : new System.Collections.Generic.List<IAnyCurrentPlayerUserDataListener>();
        listeners.Add(value);
        ReplaceAnyCurrentPlayerUserDataListener(listeners);
    }

    public void RemoveAnyCurrentPlayerUserDataListener(IAnyCurrentPlayerUserDataListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyCurrentPlayerUserDataListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyCurrentPlayerUserDataListener();
        } else {
            ReplaceAnyCurrentPlayerUserDataListener(listeners);
        }
    }
}
