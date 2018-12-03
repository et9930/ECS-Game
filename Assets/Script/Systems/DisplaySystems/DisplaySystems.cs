public class DisplaySystems : Feature
{
    public DisplaySystems(Contexts contexts) : base("Display Systems")
    {
        //Reactive Systems
        Add(new AddViewSystem(contexts));
        Add(new RenderSpriteSystem(contexts));
        Add(new RenderPositionSystem(contexts));

        //Cleanup Systems
    }
}