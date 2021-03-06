//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity pointNinjaItemMenuItemEntity { get { return GetGroup(GameMatcher.PointNinjaItemMenuItem).GetSingleEntity(); } }
    public PointNinjaItemMenuItemComponent pointNinjaItemMenuItem { get { return pointNinjaItemMenuItemEntity.pointNinjaItemMenuItem; } }
    public bool hasPointNinjaItemMenuItem { get { return pointNinjaItemMenuItemEntity != null; } }

    public GameEntity SetPointNinjaItemMenuItem(string newValue) {
        if (hasPointNinjaItemMenuItem) {
            throw new Entitas.EntitasException("Could not set PointNinjaItemMenuItem!\n" + this + " already has an entity with PointNinjaItemMenuItemComponent!",
                "You should check if the context already has a pointNinjaItemMenuItemEntity before setting it or use context.ReplacePointNinjaItemMenuItem().");
        }
        var entity = CreateEntity();
        entity.AddPointNinjaItemMenuItem(newValue);
        return entity;
    }

    public void ReplacePointNinjaItemMenuItem(string newValue) {
        var entity = pointNinjaItemMenuItemEntity;
        if (entity == null) {
            entity = SetPointNinjaItemMenuItem(newValue);
        } else {
            entity.ReplacePointNinjaItemMenuItem(newValue);
        }
    }

    public void RemovePointNinjaItemMenuItem() {
        pointNinjaItemMenuItemEntity.Destroy();
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

    public PointNinjaItemMenuItemComponent pointNinjaItemMenuItem { get { return (PointNinjaItemMenuItemComponent)GetComponent(GameComponentsLookup.PointNinjaItemMenuItem); } }
    public bool hasPointNinjaItemMenuItem { get { return HasComponent(GameComponentsLookup.PointNinjaItemMenuItem); } }

    public void AddPointNinjaItemMenuItem(string newValue) {
        var index = GameComponentsLookup.PointNinjaItemMenuItem;
        var component = (PointNinjaItemMenuItemComponent)CreateComponent(index, typeof(PointNinjaItemMenuItemComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePointNinjaItemMenuItem(string newValue) {
        var index = GameComponentsLookup.PointNinjaItemMenuItem;
        var component = (PointNinjaItemMenuItemComponent)CreateComponent(index, typeof(PointNinjaItemMenuItemComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePointNinjaItemMenuItem() {
        RemoveComponent(GameComponentsLookup.PointNinjaItemMenuItem);
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

    static Entitas.IMatcher<GameEntity> _matcherPointNinjaItemMenuItem;

    public static Entitas.IMatcher<GameEntity> PointNinjaItemMenuItem {
        get {
            if (_matcherPointNinjaItemMenuItem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PointNinjaItemMenuItem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPointNinjaItemMenuItem = matcher;
            }

            return _matcherPointNinjaItemMenuItem;
        }
    }
}
