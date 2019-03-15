//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LeftNumberListenerComponent leftNumberListener { get { return (LeftNumberListenerComponent)GetComponent(GameComponentsLookup.LeftNumberListener); } }
    public bool hasLeftNumberListener { get { return HasComponent(GameComponentsLookup.LeftNumberListener); } }

    public void AddLeftNumberListener(System.Collections.Generic.List<ILeftNumberListener> newValue) {
        var index = GameComponentsLookup.LeftNumberListener;
        var component = (LeftNumberListenerComponent)CreateComponent(index, typeof(LeftNumberListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLeftNumberListener(System.Collections.Generic.List<ILeftNumberListener> newValue) {
        var index = GameComponentsLookup.LeftNumberListener;
        var component = (LeftNumberListenerComponent)CreateComponent(index, typeof(LeftNumberListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLeftNumberListener() {
        RemoveComponent(GameComponentsLookup.LeftNumberListener);
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

    static Entitas.IMatcher<GameEntity> _matcherLeftNumberListener;

    public static Entitas.IMatcher<GameEntity> LeftNumberListener {
        get {
            if (_matcherLeftNumberListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LeftNumberListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLeftNumberListener = matcher;
            }

            return _matcherLeftNumberListener;
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

    public void AddLeftNumberListener(ILeftNumberListener value) {
        var listeners = hasLeftNumberListener
            ? leftNumberListener.value
            : new System.Collections.Generic.List<ILeftNumberListener>();
        listeners.Add(value);
        ReplaceLeftNumberListener(listeners);
    }

    public void RemoveLeftNumberListener(ILeftNumberListener value, bool removeComponentWhenEmpty = true) {
        var listeners = leftNumberListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveLeftNumberListener();
        } else {
            ReplaceLeftNumberListener(listeners);
        }
    }
}
