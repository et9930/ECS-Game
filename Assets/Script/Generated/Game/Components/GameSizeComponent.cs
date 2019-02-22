//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SizeComponent size { get { return (SizeComponent)GetComponent(GameComponentsLookup.Size); } }
    public bool hasSize { get { return HasComponent(GameComponentsLookup.Size); } }

    public void AddSize(System.Numerics.Vector2 newValue) {
        var index = GameComponentsLookup.Size;
        var component = (SizeComponent)CreateComponent(index, typeof(SizeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSize(System.Numerics.Vector2 newValue) {
        var index = GameComponentsLookup.Size;
        var component = (SizeComponent)CreateComponent(index, typeof(SizeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSize() {
        RemoveComponent(GameComponentsLookup.Size);
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

    static Entitas.IMatcher<GameEntity> _matcherSize;

    public static Entitas.IMatcher<GameEntity> Size {
        get {
            if (_matcherSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Size);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSize = matcher;
            }

            return _matcherSize;
        }
    }
}
