//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity settingValuesEntity { get { return GetGroup(GameMatcher.SettingValues).GetSingleEntity(); } }
    public SettingValuesComponent settingValues { get { return settingValuesEntity.settingValues; } }
    public bool hasSettingValues { get { return settingValuesEntity != null; } }

    public GameEntity SetSettingValues(System.Collections.Generic.List<Resolution> newResolutions, Resolution newCurrentResolution, bool newIsFullScreen) {
        if (hasSettingValues) {
            throw new Entitas.EntitasException("Could not set SettingValues!\n" + this + " already has an entity with SettingValuesComponent!",
                "You should check if the context already has a settingValuesEntity before setting it or use context.ReplaceSettingValues().");
        }
        var entity = CreateEntity();
        entity.AddSettingValues(newResolutions, newCurrentResolution, newIsFullScreen);
        return entity;
    }

    public void ReplaceSettingValues(System.Collections.Generic.List<Resolution> newResolutions, Resolution newCurrentResolution, bool newIsFullScreen) {
        var entity = settingValuesEntity;
        if (entity == null) {
            entity = SetSettingValues(newResolutions, newCurrentResolution, newIsFullScreen);
        } else {
            entity.ReplaceSettingValues(newResolutions, newCurrentResolution, newIsFullScreen);
        }
    }

    public void RemoveSettingValues() {
        settingValuesEntity.Destroy();
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

    public SettingValuesComponent settingValues { get { return (SettingValuesComponent)GetComponent(GameComponentsLookup.SettingValues); } }
    public bool hasSettingValues { get { return HasComponent(GameComponentsLookup.SettingValues); } }

    public void AddSettingValues(System.Collections.Generic.List<Resolution> newResolutions, Resolution newCurrentResolution, bool newIsFullScreen) {
        var index = GameComponentsLookup.SettingValues;
        var component = (SettingValuesComponent)CreateComponent(index, typeof(SettingValuesComponent));
        component.resolutions = newResolutions;
        component.currentResolution = newCurrentResolution;
        component.isFullScreen = newIsFullScreen;
        AddComponent(index, component);
    }

    public void ReplaceSettingValues(System.Collections.Generic.List<Resolution> newResolutions, Resolution newCurrentResolution, bool newIsFullScreen) {
        var index = GameComponentsLookup.SettingValues;
        var component = (SettingValuesComponent)CreateComponent(index, typeof(SettingValuesComponent));
        component.resolutions = newResolutions;
        component.currentResolution = newCurrentResolution;
        component.isFullScreen = newIsFullScreen;
        ReplaceComponent(index, component);
    }

    public void RemoveSettingValues() {
        RemoveComponent(GameComponentsLookup.SettingValues);
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

    static Entitas.IMatcher<GameEntity> _matcherSettingValues;

    public static Entitas.IMatcher<GameEntity> SettingValues {
        get {
            if (_matcherSettingValues == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SettingValues);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSettingValues = matcher;
            }

            return _matcherSettingValues;
        }
    }
}