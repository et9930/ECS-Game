using Entitas;
using UnityEngine;

public class InitLayersSystem : IInitializeSystem
{
    readonly Transform _layersRoot = new GameObject("UILayerRoot").transform;

    public InitLayersSystem(Contexts contexts)
    {
        Object.DontDestroyOnLoad(_layersRoot);
    }

    public void Initialize()
    {
        
    }
}