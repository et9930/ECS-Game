using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Entitas;
using UnityEngine;

public class LoadGameConfigSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public LoadGameConfigSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        // Animation Image Info
        var strImageInfo = _context.loadConfigService.instance.LoadJsonFile("Json/AnimationInfos");
        _context.ReplaceImageAsset(Utilities.ParseJson<ImageInfos>(strImageInfo));
        
        // UI Layer Config
        var strUiLayer = _context.loadConfigService.instance.LoadJsonFile("Json/UILayer");
        _context.ReplaceUiLayerConfig(Utilities.ParseJson<UiLayerInfos>(strUiLayer));

        // UI Config
        var dictionary = new Dictionary<string, UiInfo>();
        var strUiConfig = _context.loadConfigService.instance.LoadJsonFile("Json/UIConfig");
        var tempConfig = Utilities.ParseJson<UiInfoList>(strUiConfig);
        foreach (var config in tempConfig.UIConfigs)
        {
            dictionary[config.UiName] = config;
        }
        _context.ReplaceUiConfig(dictionary);

        // Scene Config
        var strSceneConfig = _context.loadConfigService.instance.LoadJsonFile("Json/SceneConfig");
        var sceneConfigs = Utilities.ParseJson<SceneConfigs>(strSceneConfig);
        _context.ReplaceSceneConfig(sceneConfigs.Scenes);

        // Loading UI Random Infos
        var strLoadingUiRandomInfo = _context.loadConfigService.instance.LoadJsonFile("Json/LoadingUIRandomInfo");
        var tempInfos = Utilities.ParseJson<LoadingUiRandomInfo>(strLoadingUiRandomInfo);
        _context.ReplaceLoadingUiRandomInfo(tempInfos.RandomTexts, tempInfos.RandomImages);

        // Character Base Attributes
        var strCharacterBaseAttributes = _context.loadConfigService.instance.LoadJsonFile("Json/CharacterBaseAttributes");
        var tempAttributes = Utilities.ParseJson<CharacterBaseAttributes>(strCharacterBaseAttributes);
        _context.ReplaceCharacterBaseAttributes(tempAttributes.list);

        // Map Config
        var strMapConfig = _context.loadConfigService.instance.LoadJsonFile("Json/MapConfig");
        var tempMapConfig = Utilities.ParseJson<MapConfigList>(strMapConfig);
        _context.ReplaceMapConfig(tempMapConfig);

        // Ninjutsu Attributes
        var strNinjutsuAttributes = _context.loadConfigService.instance.LoadJsonFile("Json/NinjutsuAttributes");
        var tempNinjutsuAttributes = Utilities.ParseJson<NinjutsuAttributes>(strNinjutsuAttributes);
        _context.ReplaceNinjutsuAttributes(tempNinjutsuAttributes.dic);

        // Ninja Item Attributes
        var strNinjaItemAttributes = _context.loadConfigService.instance.LoadJsonFile("Json/NinjaItemAttributes");
        var tempNinjaItemAttributes = Utilities.ParseJson<NinjaItemAttributes>(strNinjaItemAttributes);
        _context.ReplaceNinjaItemAttributes(tempNinjaItemAttributes.dic);
    }
}