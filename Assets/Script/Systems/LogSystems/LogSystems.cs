using Entitas;

public class LogSystems : Feature
{
    public LogSystems(Contexts contexts) : base("Log Systems")
    {
        //Reactive Systems
        Add(new DebugMessageSystem(contexts));

        //Cleanup Systems
        Add(new CleanupDebugMessageSystem(contexts));
    }
}