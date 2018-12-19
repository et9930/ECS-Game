public class SceneSystems : Feature
{
    public SceneSystems(Contexts contexts) : base("Scene Systems")
    {
        //Initialize Systems
        Add(new InitLayersSystem(contexts));

        //Reactive Systems
        Add(new SwitchSceneSystem(contexts));

        //Cleanup Systems
    }
}