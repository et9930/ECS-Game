//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PerceptionPositionExistItemListenerComponent perceptionPositionExistItemListener { get { return (PerceptionPositionExistItemListenerComponent)GetComponent(GameComponentsLookup.PerceptionPositionExistItemListener); } }
    public bool hasPerceptionPositionExistItemListener { get { return HasComponent(GameComponentsLookup.PerceptionPositionExistItemListener); } }

    public void AddPerceptionPositionExistItemListener(System.Collections.Generic.List<IPerceptionPositionExistItemListener> newValue) {
        var index = GameComponentsLookup.PerceptionPositionExistItemListener;
        var component = (PerceptionPositionExistItemListenerComponent)CreateComponent(index, typeof(PerceptionPositionExistItemListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePerceptionPositionExistItemListener(System.Collections.Generic.List<IPerceptionPositionExistItemListener> newValue) {
        var index = GameComponentsLookup.PerceptionPositionExistItemListener;
        var component = (PerceptionPositionExistItemListenerComponent)CreateComponent(index, typeof(PerceptionPositionExistItemListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePerceptionPositionExistItemListener() {
        RemoveComponent(GameComponentsLookup.PerceptionPositionExistItemListener);
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

    static Entitas.IMatcher<GameEntity> _matcherPerceptionPositionExistItemListener;

    public static Entitas.IMatcher<GameEntity> PerceptionPositionExistItemListener {
        get {
            if (_matcherPerceptionPositionExistItemListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PerceptionPositionExistItemListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPerceptionPositionExistItemListener = matcher;
            }

            return _matcherPerceptionPositionExistItemListener;
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

    public void AddPerceptionPositionExistItemListener(IPerceptionPositionExistItemListener value) {
        var listeners = hasPerceptionPositionExistItemListener
            ? perceptionPositionExistItemListener.value
            : new System.Collections.Generic.List<IPerceptionPositionExistItemListener>();
        listeners.Add(value);
        ReplacePerceptionPositionExistItemListener(listeners);
    }

    public void RemovePerceptionPositionExistItemListener(IPerceptionPositionExistItemListener value, bool removeComponentWhenEmpty = true) {
        var listeners = perceptionPositionExistItemListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemovePerceptionPositionExistItemListener();
        } else {
            ReplacePerceptionPositionExistItemListener(listeners);
        }
    }
}
