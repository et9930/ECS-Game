using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class InitLayersSystem : IInitializeSystem
{
    private readonly Transform _layersRoot = new GameObject("UILayerRoot").transform;
    private readonly GameContext _context;
    private GameEntity _uiLayerConfigEntity;

    public InitLayersSystem(Contexts contexts)
    {
        _context = contexts.game;
        Object.DontDestroyOnLoad(_layersRoot);
    }

    public void Initialize()
    {
        var layerConfig = _context.uiLayerConfig.config.UILayers;
        var layerDictionary = new Dictionary<string, GameObject>();

        foreach (var uiLayerInfo in layerConfig)
        {
            // create game object
            var layerGameObject = new GameObject(uiLayerInfo.Name);
            layerGameObject.transform.SetParent(_layersRoot);
            layerGameObject.layer = 5;

            // create canvas
            var canvas = layerGameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;
            canvas.planeDistance = uiLayerInfo.PlaneDistance;
            canvas.sortingLayerName = "UI";
            canvas.sortingOrder = uiLayerInfo.OrderInLayer;

            // create canvas scaler
            var scaler = layerGameObject.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.referenceResolution = new Vector2(1920, 1080);

            // create graphic raycaster
            layerGameObject.AddComponent<GraphicRaycaster>();

            layerDictionary[uiLayerInfo.Name] = layerGameObject;
        }

        _context.ReplaceUiLayers(layerDictionary);
        _context.uiLayerConfigEntity.isDestroy = true;
    }
}