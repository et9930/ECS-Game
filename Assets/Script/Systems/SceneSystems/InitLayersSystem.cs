using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class InitLayersSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitLayersSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var layerConfig = _context.uiLayerConfig.config;
        _context.sceneService.instance.InitializeLayers(layerConfig);
        _context.uiLayerConfigEntity.isDestroy = true;
    }
}