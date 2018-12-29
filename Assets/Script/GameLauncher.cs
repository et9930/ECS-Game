using Entitas;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    private Systems _systems;
    private Systems _physicalSystems;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Camera.main.gameObject);

        var contexts = Contexts.sharedInstance;

        var services = new Services(
            new UnityDebugLogService(),
            new UnityViewService(),
            new UnityMouseInputService(),
            new UnityLoadConfigService(),
            new UnitySceneService(),
            new GameObject("CoroutineBaseGameObject").AddComponent<UnityCoroutineService>(),
            new UnityKeyInputService()
        );

        _systems = new Feature("Systems")
            .Add(new GameWorld(contexts, services));
        _systems.Initialize();

        _physicalSystems = new Feature("Physical Systems")
            .Add(new PhysicalSystems(contexts));
        _physicalSystems.Initialize();

#if UNITY_EDITOR
        DontDestroyOnLoad(GameObject.Find("Systems"));
        DontDestroyOnLoad(GameObject.Find("Physical Systems"));
#endif
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    void FixedUpdate()
    {
        _physicalSystems.Execute();
        _physicalSystems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
        _physicalSystems.TearDown();
    }
}