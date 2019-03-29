//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SelectTargetListenerComponent selectTargetListener { get { return (SelectTargetListenerComponent)GetComponent(GameComponentsLookup.SelectTargetListener); } }
    public bool hasSelectTargetListener { get { return HasComponent(GameComponentsLookup.SelectTargetListener); } }

    public void AddSelectTargetListener(System.Collections.Generic.List<ISelectTargetListener> newValue) {
        var index = GameComponentsLookup.SelectTargetListener;
        var component = (SelectTargetListenerComponent)CreateComponent(index, typeof(SelectTargetListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSelectTargetListener(System.Collections.Generic.List<ISelectTargetListener> newValue) {
        var index = GameComponentsLookup.SelectTargetListener;
        var component = (SelectTargetListenerComponent)CreateComponent(index, typeof(SelectTargetListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSelectTargetListener() {
        RemoveComponent(GameComponentsLookup.SelectTargetListener);
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

    static Entitas.IMatcher<GameEntity> _matcherSelectTargetListener;

    public static Entitas.IMatcher<GameEntity> SelectTargetListener {
        get {
            if (_matcherSelectTargetListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SelectTargetListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSelectTargetListener = matcher;
            }

            return _matcherSelectTargetListener;
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

    public void AddSelectTargetListener(ISelectTargetListener value) {
        var listeners = hasSelectTargetListener
            ? selectTargetListener.value
            : new System.Collections.Generic.List<ISelectTargetListener>();
        listeners.Add(value);
        ReplaceSelectTargetListener(listeners);
    }

    public void RemoveSelectTargetListener(ISelectTargetListener value, bool removeComponentWhenEmpty = true) {
        var listeners = selectTargetListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSelectTargetListener();
        } else {
            ReplaceSelectTargetListener(listeners);
        }
    }
}