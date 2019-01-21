public class DisplaySystems : Feature
{
    public DisplaySystems(Contexts contexts) : base("Display Systems")
    {
        //Reactive Systems
        Add(new CalculateFpsSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new ChangeViewSystem(contexts));
        //Cleanup Systems
    }
}