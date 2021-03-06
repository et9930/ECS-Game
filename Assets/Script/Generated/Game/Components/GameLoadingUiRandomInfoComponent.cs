//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity loadingUiRandomInfoEntity { get { return GetGroup(GameMatcher.LoadingUiRandomInfo).GetSingleEntity(); } }
    public LoadingUiRandomInfoComponent loadingUiRandomInfo { get { return loadingUiRandomInfoEntity.loadingUiRandomInfo; } }
    public bool hasLoadingUiRandomInfo { get { return loadingUiRandomInfoEntity != null; } }

    public GameEntity SetLoadingUiRandomInfo(System.Collections.Generic.List<RandomText> newRandomTexts, System.Collections.Generic.List<RandomImage> newRandomImages) {
        if (hasLoadingUiRandomInfo) {
            throw new Entitas.EntitasException("Could not set LoadingUiRandomInfo!\n" + this + " already has an entity with LoadingUiRandomInfoComponent!",
                "You should check if the context already has a loadingUiRandomInfoEntity before setting it or use context.ReplaceLoadingUiRandomInfo().");
        }
        var entity = CreateEntity();
        entity.AddLoadingUiRandomInfo(newRandomTexts, newRandomImages);
        return entity;
    }

    public void ReplaceLoadingUiRandomInfo(System.Collections.Generic.List<RandomText> newRandomTexts, System.Collections.Generic.List<RandomImage> newRandomImages) {
        var entity = loadingUiRandomInfoEntity;
        if (entity == null) {
            entity = SetLoadingUiRandomInfo(newRandomTexts, newRandomImages);
        } else {
            entity.ReplaceLoadingUiRandomInfo(newRandomTexts, newRandomImages);
        }
    }

    public void RemoveLoadingUiRandomInfo() {
        loadingUiRandomInfoEntity.Destroy();
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

    public LoadingUiRandomInfoComponent loadingUiRandomInfo { get { return (LoadingUiRandomInfoComponent)GetComponent(GameComponentsLookup.LoadingUiRandomInfo); } }
    public bool hasLoadingUiRandomInfo { get { return HasComponent(GameComponentsLookup.LoadingUiRandomInfo); } }

    public void AddLoadingUiRandomInfo(System.Collections.Generic.List<RandomText> newRandomTexts, System.Collections.Generic.List<RandomImage> newRandomImages) {
        var index = GameComponentsLookup.LoadingUiRandomInfo;
        var component = (LoadingUiRandomInfoComponent)CreateComponent(index, typeof(LoadingUiRandomInfoComponent));
        component.RandomTexts = newRandomTexts;
        component.RandomImages = newRandomImages;
        AddComponent(index, component);
    }

    public void ReplaceLoadingUiRandomInfo(System.Collections.Generic.List<RandomText> newRandomTexts, System.Collections.Generic.List<RandomImage> newRandomImages) {
        var index = GameComponentsLookup.LoadingUiRandomInfo;
        var component = (LoadingUiRandomInfoComponent)CreateComponent(index, typeof(LoadingUiRandomInfoComponent));
        component.RandomTexts = newRandomTexts;
        component.RandomImages = newRandomImages;
        ReplaceComponent(index, component);
    }

    public void RemoveLoadingUiRandomInfo() {
        RemoveComponent(GameComponentsLookup.LoadingUiRandomInfo);
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

    static Entitas.IMatcher<GameEntity> _matcherLoadingUiRandomInfo;

    public static Entitas.IMatcher<GameEntity> LoadingUiRandomInfo {
        get {
            if (_matcherLoadingUiRandomInfo == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LoadingUiRandomInfo);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLoadingUiRandomInfo = matcher;
            }

            return _matcherLoadingUiRandomInfo;
        }
    }
}
