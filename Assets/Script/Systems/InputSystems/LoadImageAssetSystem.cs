using Entitas;
using UnityEngine;

public class LoadImageAssetSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private GameEntity _animationInfosEntity;

    public LoadImageAssetSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    { 
        Object asset = Resources.Load("Image/AnimationInfos");
        _context.ReplaceImageAsset((Infos)asset);
        _animationInfosEntity = _context.imageAssetEntity;
    }
}