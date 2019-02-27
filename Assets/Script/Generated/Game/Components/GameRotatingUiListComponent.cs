//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity rotatingUiListEntity { get { return GetGroup(GameMatcher.RotatingUiList).GetSingleEntity(); } }
    public RotatingUiListComponent rotatingUiList { get { return rotatingUiListEntity.rotatingUiList; } }
    public bool hasRotatingUiList { get { return rotatingUiListEntity != null; } }

    public GameEntity SetRotatingUiList(System.Collections.Generic.List<string> newList) {
        if (hasRotatingUiList) {
            throw new Entitas.EntitasException("Could not set RotatingUiList!\n" + this + " already has an entity with RotatingUiListComponent!",
                "You should check if the context already has a rotatingUiListEntity before setting it or use context.ReplaceRotatingUiList().");
        }
        var entity = CreateEntity();
        entity.AddRotatingUiList(newList);
        return entity;
    }

    public void ReplaceRotatingUiList(System.Collections.Generic.List<string> newList) {
        var entity = rotatingUiListEntity;
        if (entity == null) {
            entity = SetRotatingUiList(newList);
        } else {
            entity.ReplaceRotatingUiList(newList);
        }
    }

    public void RemoveRotatingUiList() {
        rotatingUiListEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public RotatingUiListComponent rotatingUiList { get { return (RotatingUiListComponent)GetComponent(GameComponentsLookup.RotatingUiList); } }
    public bool hasRotatingUiList { get { return HasComponent(GameComponentsLookup.RotatingUiList); } }

    public void AddRotatingUiList(System.Collections.Generic.List<string> newList) {
        var index = GameComponentsLookup.RotatingUiList;
        var component = (RotatingUiListComponent)CreateComponent(index, typeof(RotatingUiListComponent));
        component.list = newList;
        AddComponent(index, component);
    }

    public void ReplaceRotatingUiList(System.Collections.Generic.List<string> newList) {
        var index = GameComponentsLookup.RotatingUiList;
        var component = (RotatingUiListComponent)CreateComponent(index, typeof(RotatingUiListComponent));
        component.list = newList;
        ReplaceComponent(index, component);
    }

    public void RemoveRotatingUiList() {
        RemoveComponent(GameComponentsLookup.RotatingUiList);
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

    static Entitas.IMatcher<GameEntity> _matcherRotatingUiList;

    public static Entitas.IMatcher<GameEntity> RotatingUiList {
        get {
            if (_matcherRotatingUiList == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RotatingUiList);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotatingUiList = matcher;
            }

            return _matcherRotatingUiList;
        }
    }
}
