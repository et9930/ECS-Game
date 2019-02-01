//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyTaiRyoKuListenerComponent anyTaiRyoKuListener { get { return (AnyTaiRyoKuListenerComponent)GetComponent(GameComponentsLookup.AnyTaiRyoKuListener); } }
    public bool hasAnyTaiRyoKuListener { get { return HasComponent(GameComponentsLookup.AnyTaiRyoKuListener); } }

    public void AddAnyTaiRyoKuListener(System.Collections.Generic.List<IAnyTaiRyoKuListener> newValue) {
        var index = GameComponentsLookup.AnyTaiRyoKuListener;
        var component = (AnyTaiRyoKuListenerComponent)CreateComponent(index, typeof(AnyTaiRyoKuListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyTaiRyoKuListener(System.Collections.Generic.List<IAnyTaiRyoKuListener> newValue) {
        var index = GameComponentsLookup.AnyTaiRyoKuListener;
        var component = (AnyTaiRyoKuListenerComponent)CreateComponent(index, typeof(AnyTaiRyoKuListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyTaiRyoKuListener() {
        RemoveComponent(GameComponentsLookup.AnyTaiRyoKuListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyTaiRyoKuListener;

    public static Entitas.IMatcher<GameEntity> AnyTaiRyoKuListener {
        get {
            if (_matcherAnyTaiRyoKuListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyTaiRyoKuListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyTaiRyoKuListener = matcher;
            }

            return _matcherAnyTaiRyoKuListener;
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

    public void AddAnyTaiRyoKuListener(IAnyTaiRyoKuListener value) {
        var listeners = hasAnyTaiRyoKuListener
            ? anyTaiRyoKuListener.value
            : new System.Collections.Generic.List<IAnyTaiRyoKuListener>();
        listeners.Add(value);
        ReplaceAnyTaiRyoKuListener(listeners);
    }

    public void RemoveAnyTaiRyoKuListener(IAnyTaiRyoKuListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyTaiRyoKuListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyTaiRyoKuListener();
        } else {
            ReplaceAnyTaiRyoKuListener(listeners);
        }
    }
}
