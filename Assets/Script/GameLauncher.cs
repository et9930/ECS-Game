﻿using Entitas;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    private Systems _systems;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Camera.main.gameObject);
        DontDestroyOnLoad(GameObject.Find("EventSystem"));

        var contexts = Contexts.sharedInstance;

        var services = new Services(
            new UnityDebugLogService(), 
            new UnityViewService(),
            new UnityMouseInputService(),
            new UnityLoadConfigService(),
            new UnitySceneService(),
            new GameObject("CoroutineBaseGameObject").AddComponent<UnityCoroutineService>(),
            new UnityKeyInputService(),
            new UnityTimeService(),
            new UnityPhysicsService(),
            new NakamaNetworkService(),
            new UnityLocalStorageService(),
            new UnityFileService(),
            new UnitySettingService()
        );

        _systems = new Feature("Systems")
            .Add(new GameWorld(contexts, services));
        _systems.Initialize();

#if UNITY_EDITOR && (!ENTITAS_DISABLE_DEEP_PROFILING || !ENTITAS_DISABLE_VISUAL_DEBUGGING)
        DontDestroyOnLoad(GameObject.Find("Systems"));
#endif
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

//    void FixedUpdate()
//    {
//        _systems.Execute();
//        _systems.Cleanup();
//    }

    void OnDestroy()
    {
        _systems.TearDown();
    }
}