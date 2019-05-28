//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity battleOverEntity { get { return GetGroup(GameMatcher.BattleOver).GetSingleEntity(); } }
    public BattleOverComponent battleOver { get { return battleOverEntity.battleOver; } }
    public bool hasBattleOver { get { return battleOverEntity != null; } }

    public GameEntity SetBattleOver(int newWinTeam) {
        if (hasBattleOver) {
            throw new Entitas.EntitasException("Could not set BattleOver!\n" + this + " already has an entity with BattleOverComponent!",
                "You should check if the context already has a battleOverEntity before setting it or use context.ReplaceBattleOver().");
        }
        var entity = CreateEntity();
        entity.AddBattleOver(newWinTeam);
        return entity;
    }

    public void ReplaceBattleOver(int newWinTeam) {
        var entity = battleOverEntity;
        if (entity == null) {
            entity = SetBattleOver(newWinTeam);
        } else {
            entity.ReplaceBattleOver(newWinTeam);
        }
    }

    public void RemoveBattleOver() {
        battleOverEntity.Destroy();
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

    public BattleOverComponent battleOver { get { return (BattleOverComponent)GetComponent(GameComponentsLookup.BattleOver); } }
    public bool hasBattleOver { get { return HasComponent(GameComponentsLookup.BattleOver); } }

    public void AddBattleOver(int newWinTeam) {
        var index = GameComponentsLookup.BattleOver;
        var component = (BattleOverComponent)CreateComponent(index, typeof(BattleOverComponent));
        component.winTeam = newWinTeam;
        AddComponent(index, component);
    }

    public void ReplaceBattleOver(int newWinTeam) {
        var index = GameComponentsLookup.BattleOver;
        var component = (BattleOverComponent)CreateComponent(index, typeof(BattleOverComponent));
        component.winTeam = newWinTeam;
        ReplaceComponent(index, component);
    }

    public void RemoveBattleOver() {
        RemoveComponent(GameComponentsLookup.BattleOver);
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

    static Entitas.IMatcher<GameEntity> _matcherBattleOver;

    public static Entitas.IMatcher<GameEntity> BattleOver {
        get {
            if (_matcherBattleOver == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BattleOver);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBattleOver = matcher;
            }

            return _matcherBattleOver;
        }
    }
}
