public class InputSystems : Feature
{
    public InputSystems(Contexts contexts) : base("Input Systems")
    {
        //Initialize Systems
        Add(new LoadGameConfigSystem(contexts));

        //Reactive Systems
        Add(new EmitInputSystem(contexts));
        Add(new CreatePlayerSystem(contexts));
        Add(new SetMoveTargetSystem(contexts));

        //Cleanup Systems
    }
}