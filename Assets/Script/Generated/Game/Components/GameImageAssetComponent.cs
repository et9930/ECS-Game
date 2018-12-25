//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity imageAssetEntity { get { return GetGroup(GameMatcher.ImageAsset).GetSingleEntity(); } }
    public ImageAssetComponent imageAsset { get { return imageAssetEntity.imageAsset; } }
    public bool hasImageAsset { get { return imageAssetEntity != null; } }

    public GameEntity SetImageAsset(ImageInfos newImageInfos) {
        if (hasImageAsset) {
            throw new Entitas.EntitasException("Could not set ImageAsset!\n" + this + " already has an entity with ImageAssetComponent!",
                "You should check if the context already has a imageAssetEntity before setting it or use context.ReplaceImageAsset().");
        }
        var entity = CreateEntity();
        entity.AddImageAsset(newImageInfos);
        return entity;
    }

    public void ReplaceImageAsset(ImageInfos newImageInfos) {
        var entity = imageAssetEntity;
        if (entity == null) {
            entity = SetImageAsset(newImageInfos);
        } else {
            entity.ReplaceImageAsset(newImageInfos);
        }
    }

    public void RemoveImageAsset() {
        imageAssetEntity.Destroy();
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

    public ImageAssetComponent imageAsset { get { return (ImageAssetComponent)GetComponent(GameComponentsLookup.ImageAsset); } }
    public bool hasImageAsset { get { return HasComponent(GameComponentsLookup.ImageAsset); } }

    public void AddImageAsset(ImageInfos newImageInfos) {
        var index = GameComponentsLookup.ImageAsset;
        var component = (ImageAssetComponent)CreateComponent(index, typeof(ImageAssetComponent));
        component.imageInfos = newImageInfos;
        AddComponent(index, component);
    }

    public void ReplaceImageAsset(ImageInfos newImageInfos) {
        var index = GameComponentsLookup.ImageAsset;
        var component = (ImageAssetComponent)CreateComponent(index, typeof(ImageAssetComponent));
        component.imageInfos = newImageInfos;
        ReplaceComponent(index, component);
    }

    public void RemoveImageAsset() {
        RemoveComponent(GameComponentsLookup.ImageAsset);
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

    static Entitas.IMatcher<GameEntity> _matcherImageAsset;

    public static Entitas.IMatcher<GameEntity> ImageAsset {
        get {
            if (_matcherImageAsset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ImageAsset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherImageAsset = matcher;
            }

            return _matcherImageAsset;
        }
    }
}
