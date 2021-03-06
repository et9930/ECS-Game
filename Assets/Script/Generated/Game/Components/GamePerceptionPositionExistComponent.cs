//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity perceptionPositionExistEntity { get { return GetGroup(GameMatcher.PerceptionPositionExist).GetSingleEntity(); } }
    public PerceptionPositionExistComponent perceptionPositionExist { get { return perceptionPositionExistEntity.perceptionPositionExist; } }
    public bool hasPerceptionPositionExist { get { return perceptionPositionExistEntity != null; } }

    public GameEntity SetPerceptionPositionExist(System.Collections.Generic.Dictionary<string, GameEntity> newDic) {
        if (hasPerceptionPositionExist) {
            throw new Entitas.EntitasException("Could not set PerceptionPositionExist!\n" + this + " already has an entity with PerceptionPositionExistComponent!",
                "You should check if the context already has a perceptionPositionExistEntity before setting it or use context.ReplacePerceptionPositionExist().");
        }
        var entity = CreateEntity();
        entity.AddPerceptionPositionExist(newDic);
        return entity;
    }

    public void ReplacePerceptionPositionExist(System.Collections.Generic.Dictionary<string, GameEntity> newDic) {
        var entity = perceptionPositionExistEntity;
        if (entity == null) {
            entity = SetPerceptionPositionExist(newDic);
        } else {
            entity.ReplacePerceptionPositionExist(newDic);
        }
    }

    public void RemovePerceptionPositionExist() {
        perceptionPositionExistEntity.Destroy();
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

    public PerceptionPositionExistComponent perceptionPositionExist { get { return (PerceptionPositionExistComponent)GetComponent(GameComponentsLookup.PerceptionPositionExist); } }
    public bool hasPerceptionPositionExist { get { return HasComponent(GameComponentsLookup.PerceptionPositionExist); } }

    public void AddPerceptionPositionExist(System.Collections.Generic.Dictionary<string, GameEntity> newDic) {
        var index = GameComponentsLookup.PerceptionPositionExist;
        var component = (PerceptionPositionExistComponent)CreateComponent(index, typeof(PerceptionPositionExistComponent));
        component.dic = newDic;
        AddComponent(index, component);
    }

    public void ReplacePerceptionPositionExist(System.Collections.Generic.Dictionary<string, GameEntity> newDic) {
        var index = GameComponentsLookup.PerceptionPositionExist;
        var component = (PerceptionPositionExistComponent)CreateComponent(index, typeof(PerceptionPositionExistComponent));
        component.dic = newDic;
        ReplaceComponent(index, component);
    }

    public void RemovePerceptionPositionExist() {
        RemoveComponent(GameComponentsLookup.PerceptionPositionExist);
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

    static Entitas.IMatcher<GameEntity> _matcherPerceptionPositionExist;

    public static Entitas.IMatcher<GameEntity> PerceptionPositionExist {
        get {
            if (_matcherPerceptionPositionExist == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PerceptionPositionExist);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPerceptionPositionExist = matcher;
            }

            return _matcherPerceptionPositionExist;
        }
    }
}
