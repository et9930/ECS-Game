//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyChaKuRaCurrentListenerComponent anyChaKuRaCurrentListener { get { return (AnyChaKuRaCurrentListenerComponent)GetComponent(GameComponentsLookup.AnyChaKuRaCurrentListener); } }
    public bool hasAnyChaKuRaCurrentListener { get { return HasComponent(GameComponentsLookup.AnyChaKuRaCurrentListener); } }

    public void AddAnyChaKuRaCurrentListener(System.Collections.Generic.List<IAnyChaKuRaCurrentListener> newValue) {
        var index = GameComponentsLookup.AnyChaKuRaCurrentListener;
        var component = (AnyChaKuRaCurrentListenerComponent)CreateComponent(index, typeof(AnyChaKuRaCurrentListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyChaKuRaCurrentListener(System.Collections.Generic.List<IAnyChaKuRaCurrentListener> newValue) {
        var index = GameComponentsLookup.AnyChaKuRaCurrentListener;
        var component = (AnyChaKuRaCurrentListenerComponent)CreateComponent(index, typeof(AnyChaKuRaCurrentListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyChaKuRaCurrentListener() {
        RemoveComponent(GameComponentsLookup.AnyChaKuRaCurrentListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyChaKuRaCurrentListener;

    public static Entitas.IMatcher<GameEntity> AnyChaKuRaCurrentListener {
        get {
            if (_matcherAnyChaKuRaCurrentListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyChaKuRaCurrentListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyChaKuRaCurrentListener = matcher;
            }

            return _matcherAnyChaKuRaCurrentListener;
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

    public void AddAnyChaKuRaCurrentListener(IAnyChaKuRaCurrentListener value) {
        var listeners = hasAnyChaKuRaCurrentListener
            ? anyChaKuRaCurrentListener.value
            : new System.Collections.Generic.List<IAnyChaKuRaCurrentListener>();
        listeners.Add(value);
        ReplaceAnyChaKuRaCurrentListener(listeners);
    }

    public void RemoveAnyChaKuRaCurrentListener(IAnyChaKuRaCurrentListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyChaKuRaCurrentListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyChaKuRaCurrentListener();
        } else {
            ReplaceAnyChaKuRaCurrentListener(listeners);
        }
    }
}