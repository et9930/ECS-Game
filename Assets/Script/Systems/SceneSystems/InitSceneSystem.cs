using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class InitSceneSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitSceneSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var layerConfig = _context.uiLayerConfig.config;
        _context.sceneService.instance.InitializeLayers(layerConfig);
        _context.uiLayerConfigEntity.isDestroy = true;

        _context.ReplaceUuidToEntity(new Dictionary<int, GameEntity>());
    }
}