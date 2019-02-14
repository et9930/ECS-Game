//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyHealthCurrentListenerComponent anyHealthCurrentListener { get { return (AnyHealthCurrentListenerComponent)GetComponent(GameComponentsLookup.AnyHealthCurrentListener); } }
    public bool hasAnyHealthCurrentListener { get { return HasComponent(GameComponentsLookup.AnyHealthCurrentListener); } }

    public void AddAnyHealthCurrentListener(System.Collections.Generic.List<IAnyHealthCurrentListener> newValue) {
        var index = GameComponentsLookup.AnyHealthCurrentListener;
        var component = (AnyHealthCurrentListenerComponent)CreateComponent(index, typeof(AnyHealthCurrentListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyHealthCurrentListener(System.Collections.Generic.List<IAnyHealthCurrentListener> newValue) {
        var index = GameComponentsLookup.AnyHealthCurrentListener;
        var component = (AnyHealthCurrentListenerComponent)CreateComponent(index, typeof(AnyHealthCurrentListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyHealthCurrentListener() {
        RemoveComponent(GameComponentsLookup.AnyHealthCurrentListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyHealthCurrentListener;

    public static Entitas.IMatcher<GameEntity> AnyHealthCurrentListener {
        get {
            if (_matcherAnyHealthCurrentListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyHealthCurrentListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyHealthCurrentListener = matcher;
            }

            return _matcherAnyHealthCurrentListener;
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

    public void AddAnyHealthCurrentListener(IAnyHealthCurrentListener value) {
        var listeners = hasAnyHealthCurrentListener
            ? anyHealthCurrentListener.value
            : new System.Collections.Generic.List<IAnyHealthCurrentListener>();
        listeners.Add(value);
        ReplaceAnyHealthCurrentListener(listeners);
    }

    public void RemoveAnyHealthCurrentListener(IAnyHealthCurrentListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyHealthCurrentListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyHealthCurrentListener();
        } else {
            ReplaceAnyHealthCurrentListener(listeners);
        }
    }
}
