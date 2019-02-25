//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity yinFreezeEntity { get { return GetGroup(GameMatcher.YinFreeze).GetSingleEntity(); } }
    public YinFreezeComponent yinFreeze { get { return yinFreezeEntity.yinFreeze; } }
    public bool hasYinFreeze { get { return yinFreezeEntity != null; } }

    public GameEntity SetYinFreeze(bool newYin1Freezing, bool newYin2Freezing, bool newYin3Freezing, bool newYin4Freezing, bool newYin5Freezing, bool newYin6Freezing, bool newYinCompleteFreezing) {
        if (hasYinFreeze) {
            throw new Entitas.EntitasException("Could not set YinFreeze!\n" + this + " already has an entity with YinFreezeComponent!",
                "You should check if the context already has a yinFreezeEntity before setting it or use context.ReplaceYinFreeze().");
        }
        var entity = CreateEntity();
        entity.AddYinFreeze(newYin1Freezing, newYin2Freezing, newYin3Freezing, newYin4Freezing, newYin5Freezing, newYin6Freezing, newYinCompleteFreezing);
        return entity;
    }

    public void ReplaceYinFreeze(bool newYin1Freezing, bool newYin2Freezing, bool newYin3Freezing, bool newYin4Freezing, bool newYin5Freezing, bool newYin6Freezing, bool newYinCompleteFreezing) {
        var entity = yinFreezeEntity;
        if (entity == null) {
            entity = SetYinFreeze(newYin1Freezing, newYin2Freezing, newYin3Freezing, newYin4Freezing, newYin5Freezing, newYin6Freezing, newYinCompleteFreezing);
        } else {
            entity.ReplaceYinFreeze(newYin1Freezing, newYin2Freezing, newYin3Freezing, newYin4Freezing, newYin5Freezing, newYin6Freezing, newYinCompleteFreezing);
        }
    }

    public void RemoveYinFreeze() {
        yinFreezeEntity.Destroy();
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

    public YinFreezeComponent yinFreeze { get { return (YinFreezeComponent)GetComponent(GameComponentsLookup.YinFreeze); } }
    public bool hasYinFreeze { get { return HasComponent(GameComponentsLookup.YinFreeze); } }

    public void AddYinFreeze(bool newYin1Freezing, bool newYin2Freezing, bool newYin3Freezing, bool newYin4Freezing, bool newYin5Freezing, bool newYin6Freezing, bool newYinCompleteFreezing) {
        var index = GameComponentsLookup.YinFreeze;
        var component = (YinFreezeComponent)CreateComponent(index, typeof(YinFreezeComponent));
        component.Yin1Freezing = newYin1Freezing;
        component.Yin2Freezing = newYin2Freezing;
        component.Yin3Freezing = newYin3Freezing;
        component.Yin4Freezing = newYin4Freezing;
        component.Yin5Freezing = newYin5Freezing;
        component.Yin6Freezing = newYin6Freezing;
        component.YinCompleteFreezing = newYinCompleteFreezing;
        AddComponent(index, component);
    }

    public void ReplaceYinFreeze(bool newYin1Freezing, bool newYin2Freezing, bool newYin3Freezing, bool newYin4Freezing, bool newYin5Freezing, bool newYin6Freezing, bool newYinCompleteFreezing) {
        var index = GameComponentsLookup.YinFreeze;
        var component = (YinFreezeComponent)CreateComponent(index, typeof(YinFreezeComponent));
        component.Yin1Freezing = newYin1Freezing;
        component.Yin2Freezing = newYin2Freezing;
        component.Yin3Freezing = newYin3Freezing;
        component.Yin4Freezing = newYin4Freezing;
        component.Yin5Freezing = newYin5Freezing;
        component.Yin6Freezing = newYin6Freezing;
        component.YinCompleteFreezing = newYinCompleteFreezing;
        ReplaceComponent(index, component);
    }

    public void RemoveYinFreeze() {
        RemoveComponent(GameComponentsLookup.YinFreeze);
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

    static Entitas.IMatcher<GameEntity> _matcherYinFreeze;

    public static Entitas.IMatcher<GameEntity> YinFreeze {
        get {
            if (_matcherYinFreeze == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.YinFreeze);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherYinFreeze = matcher;
            }

            return _matcherYinFreeze;
        }
    }
}
