public class DisplaySystems : Feature
{
    public DisplaySystems(Contexts contexts) : base("Display Systems")
    {
        //Reactive Systems
        Add(new AddViewSystem(contexts));

        //Cleanup Systems
    }
}