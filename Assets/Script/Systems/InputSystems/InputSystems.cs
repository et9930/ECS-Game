public class InputSystems : Feature
{
    public InputSystems(Contexts contexts) : base("Input Systems")
    {
        //Initialize Systems
        Add(new LoadGameConfigSystem(contexts));

        //Reactive Systems
        Add(new EmitInputSystem(contexts));

        //Cleanup Systems
    }
}