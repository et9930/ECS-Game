public class PlayerControlSystems : Feature
{
    public PlayerControlSystems(Contexts contexts) : base("Player Control Systems")
    {
        Add(new MovementControlSystem(contexts));
    }
}