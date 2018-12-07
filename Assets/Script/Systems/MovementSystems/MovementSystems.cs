public class MovementSystems : Feature
{
    public MovementSystems(Contexts contexts) : base("Movement Systems")
    {
        //Reactive Systems
        Add(new ChangeSpeedSystem(contexts));
        Add(new MoveSystem(contexts));

        //Cleanup Systems
    }
}