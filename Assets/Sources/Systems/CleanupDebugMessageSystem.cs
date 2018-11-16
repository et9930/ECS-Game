﻿// -----------------------------
// Solution: ECS-Game
// File name: CleanupDebugMessageSystem.cs
// -----------------------------
// Author: 王超
// Create in: 2018-11-17 2:51
// -----------------------------
// Modifier: 王超
// Modify in: 2018-11-17 2:52
// -----------------------------
using Entitas;

public class CleanupDebugMessageSystem : ICleanupSystem
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _debugMessages;

    public CleanupDebugMessageSystem(Contexts contexts)
    {
        _context = contexts.game;
        _debugMessages = _context.GetGroup(GameMatcher.DebugMessage);
    }

    public void Cleanup()
    {
        // group.GetEntities() always gives us an up to date list
        foreach (var e in _debugMessages.GetEntities())
        {
            e.Destroy();
        }
    }
}