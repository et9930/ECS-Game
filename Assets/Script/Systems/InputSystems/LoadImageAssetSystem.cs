using Entitas;
using UnityEngine;

public class LoadImageAssetSystem : IInitializeSystem
{
    readonly InputContext _context;
    private InputEntity _animationInfosEntity;

    public LoadImageAssetSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    { 
        Object asset = Resources.Load("Image/AnimationInfos");
        _context.ReplaceImageAsset((Infos)asset);
        _animationInfosEntity = _context.imageAssetEntity;
    }
}