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
        // Animation Image Asset
        Object asset = Resources.Load("Image/AnimationInfos");
        _context.ReplaceImageAsset((Infos)asset);

        // UI Layer Config
        var configObj = Resources.Load("Json/UILayer");
        var jsonString = configObj.ToString();
        _context.ReplaceUiLayerConfig(JsonUtility.FromJson<UiLayers>(jsonString));

    }
}