//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class SceneEntity {

    static readonly LayerComponent layerComponent = new LayerComponent();

    public bool isLayer {
        get { return HasComponent(SceneComponentsLookup.Layer); }
        set {
            if (value != isLayer) {
                var index = SceneComponentsLookup.Layer;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : layerComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
public sealed partial class SceneMatcher {

    static Entitas.IMatcher<SceneEntity> _matcherLayer;

    public static Entitas.IMatcher<SceneEntity> Layer {
        get {
            if (_matcherLayer == null) {
                var matcher = (Entitas.Matcher<SceneEntity>)Entitas.Matcher<SceneEntity>.AllOf(SceneComponentsLookup.Layer);
                matcher.componentNames = SceneComponentsLookup.componentNames;
                _matcherLayer = matcher;
            }

            return _matcherLayer;
        }
    }
}
