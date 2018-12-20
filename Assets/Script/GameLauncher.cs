using Entitas;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    private Systems _systems;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // get a reference to the contexts
        var contexts = Contexts.sharedInstance;

        var services = new Services(
            new UnityDebugLogService(),
            new UnityViewService(),
            new UnityMouseInputService()
        );

        // create the systems by creating individual features
        _systems = new Feature("Systems")
            .Add(new GameWorld(contexts, services));

        // call Initialize() on all of the IInitializeSystems
        _systems.Initialize();
    }

    void Update()
    {
        // call Execute() on all the IExecuteSystems and 
        // ReactiveSystems that were triggered last frame
        _systems.Execute();
        // call cleanup() on all the ICleanupSystems
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }
}