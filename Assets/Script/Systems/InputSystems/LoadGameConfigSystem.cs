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
    }
}