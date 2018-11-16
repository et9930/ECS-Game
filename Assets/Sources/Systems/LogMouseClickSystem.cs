// -----------------------------
// Solution: ECS-Game
// File name: LogMouseClickSystem.cs
// -----------------------------
// Author: 王超
// Create in: 2018-11-17 2:52
// -----------------------------
// Modifier: 王超
// Modify in: 2018-11-17 2:53
// -----------------------------
using Entitas;
using UnityEngine;

public class LogMouseClickSystem : IExecuteSystem
{
    readonly GameContext _context;

    public LogMouseClickSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _context.CreateEntity().AddDebugMessage("Left Mouse Button Clicked");
        }

        if (Input.GetMouseButtonDown(1))
        {
            _context.CreateEntity().AddDebugMessage("Right Mouse Button Clicked");
        }
    }
}