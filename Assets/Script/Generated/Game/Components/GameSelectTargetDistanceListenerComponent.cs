//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SelectTargetDistanceListenerComponent selectTargetDistanceListener { get { return (SelectTargetDistanceListenerComponent)GetComponent(GameComponentsLookup.SelectTargetDistanceListener); } }
    public bool hasSelectTargetDistanceListener { get { return HasComponent(GameComponentsLookup.SelectTargetDistanceListener); } }

    public void AddSelectTargetDistanceListener(System.Collections.Generic.List<ISelectTargetDistanceListener> newValue) {
        var index = GameComponentsLookup.SelectTargetDistanceListener;
        var component = (SelectTargetDistanceListenerComponent)CreateComponent(index, typeof(SelectTargetDistanceListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSelectTargetDistanceListener(System.Collections.Generic.List<ISelectTargetDistanceListener> newValue) {
        var index = GameComponentsLookup.SelectTargetDistanceListener;
        var component = (SelectTargetDistanceListenerComponent)CreateComponent(index, typeof(SelectTargetDistanceListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSelectTargetDistanceListener() {
        RemoveComponent(GameComponentsLookup.SelectTargetDistanceListener);
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

    static Entitas.IMatcher<GameEntity> _matcherSelectTargetDistanceListener;

    public static Entitas.IMatcher<GameEntity> SelectTargetDistanceListener {
        get {
            if (_matcherSelectTargetDistanceListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SelectTargetDistanceListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSelectTargetDistanceListener = matcher;
            }

            return _matcherSelectTargetDistanceListener;
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

    public void AddSelectTargetDistanceListener(ISelectTargetDistanceListener value) {
        var listeners = hasSelectTargetDistanceListener
            ? selectTargetDistanceListener.value
            : new System.Collections.Generic.List<ISelectTargetDistanceListener>();
        listeners.Add(value);
        ReplaceSelectTargetDistanceListener(listeners);
    }

    public void RemoveSelectTargetDistanceListener(ISelectTargetDistanceListener value, bool removeComponentWhenEmpty = true) {
        var listeners = selectTargetDistanceListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSelectTargetDistanceListener();
        } else {
            ReplaceSelectTargetDistanceListener(listeners);
        }
    }
}
