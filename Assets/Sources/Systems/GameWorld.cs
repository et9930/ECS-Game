using Entitas;

public class GameWorld : Feature
{
    public GameWorld(Contexts contexts) : base("Game World")
    {
        Add(new LogSystems(contexts));
    }
}