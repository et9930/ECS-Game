// -----------------------------
// Solution: ECS-Game
// File name: GameController.cs
// -----------------------------
// Author: 王超
// Create in: 2018-11-17 2:39
// -----------------------------
// Modifier: 王超
// Modify in: 2018-11-17 2:39
// -----------------------------
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Systems _systems;

    void Start()
    {
        // get a reference to the contexts
        var contexts = Contexts.sharedInstance;

        // create the systems by creating individual features
        _systems = new Feature("Systems")
            .Add(new GameWorld(contexts));

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
}