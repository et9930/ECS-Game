//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity throwWeaponNumberEntity { get { return GetGroup(GameMatcher.ThrowWeaponNumber).GetSingleEntity(); } }
    public ThrowWeaponNumberComponent throwWeaponNumber { get { return throwWeaponNumberEntity.throwWeaponNumber; } }
    public bool hasThrowWeaponNumber { get { return throwWeaponNumberEntity != null; } }

    public GameEntity SetThrowWeaponNumber(int newValue) {
        if (hasThrowWeaponNumber) {
            throw new Entitas.EntitasException("Could not set ThrowWeaponNumber!\n" + this + " already has an entity with ThrowWeaponNumberComponent!",
                "You should check if the context already has a throwWeaponNumberEntity before setting it or use context.ReplaceThrowWeaponNumber().");
        }
        var entity = CreateEntity();
        entity.AddThrowWeaponNumber(newValue);
        return entity;
    }

    public void ReplaceThrowWeaponNumber(int newValue) {
        var entity = throwWeaponNumberEntity;
        if (entity == null) {
            entity = SetThrowWeaponNumber(newValue);
        } else {
            entity.ReplaceThrowWeaponNumber(newValue);
        }
    }

    public void RemoveThrowWeaponNumber() {
        throwWeaponNumberEntity.Destroy();
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

    public ThrowWeaponNumberComponent throwWeaponNumber { get { return (ThrowWeaponNumberComponent)GetComponent(GameComponentsLookup.ThrowWeaponNumber); } }
    public bool hasThrowWeaponNumber { get { return HasComponent(GameComponentsLookup.ThrowWeaponNumber); } }

    public void AddThrowWeaponNumber(int newValue) {
        var index = GameComponentsLookup.ThrowWeaponNumber;
        var component = (ThrowWeaponNumberComponent)CreateComponent(index, typeof(ThrowWeaponNumberComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceThrowWeaponNumber(int newValue) {
        var index = GameComponentsLookup.ThrowWeaponNumber;
        var component = (ThrowWeaponNumberComponent)CreateComponent(index, typeof(ThrowWeaponNumberComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveThrowWeaponNumber() {
        RemoveComponent(GameComponentsLookup.ThrowWeaponNumber);
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

    static Entitas.IMatcher<GameEntity> _matcherThrowWeaponNumber;

    public static Entitas.IMatcher<GameEntity> ThrowWeaponNumber {
        get {
            if (_matcherThrowWeaponNumber == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ThrowWeaponNumber);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherThrowWeaponNumber = matcher;
            }

            return _matcherThrowWeaponNumber;
        }
    }
}
