// -----------------------------
// Solution: ECS-Game
// File name: TutorialSystems.cs
// -----------------------------
// Author: 王超
// Create in: 2018-11-17 2:38
// -----------------------------
// Modifier: 王超
// Modify in: 2018-11-17 2:38
// -----------------------------
using Entitas;

public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("Tutorial Systems")
    {
        Add(new HelloWorldSystem(contexts));
        Add(new LogMouseClickSystem(contexts)); // new system
        Add(new DebugMessageSystem(contexts));
        Add(new CleanupDebugMessageSystem(contexts)); // new system (we want this to run last)
    }
}