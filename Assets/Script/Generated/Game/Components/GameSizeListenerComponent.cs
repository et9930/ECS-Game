//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SizeListenerComponent sizeListener { get { return (SizeListenerComponent)GetComponent(GameComponentsLookup.SizeListener); } }
    public bool hasSizeListener { get { return HasComponent(GameComponentsLookup.SizeListener); } }

    public void AddSizeListener(System.Collections.Generic.List<ISizeListener> newValue) {
        var index = GameComponentsLookup.SizeListener;
        var component = (SizeListenerComponent)CreateComponent(index, typeof(SizeListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSizeListener(System.Collections.Generic.List<ISizeListener> newValue) {
        var index = GameComponentsLookup.SizeListener;
        var component = (SizeListenerComponent)CreateComponent(index, typeof(SizeListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSizeListener() {
        RemoveComponent(GameComponentsLookup.SizeListener);
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

    static Entitas.IMatcher<GameEntity> _matcherSizeListener;

    public static Entitas.IMatcher<GameEntity> SizeListener {
        get {
            if (_matcherSizeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SizeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSizeListener = matcher;
            }

            return _matcherSizeListener;
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

    public void AddSizeListener(ISizeListener value) {
        var listeners = hasSizeListener
            ? sizeListener.value
            : new System.Collections.Generic.List<ISizeListener>();
        listeners.Add(value);
        ReplaceSizeListener(listeners);
    }

    public void RemoveSizeListener(ISizeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = sizeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSizeListener();
        } else {
            ReplaceSizeListener(listeners);
        }
    }
}
