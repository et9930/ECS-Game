public class SceneSystems : Feature
{
    public SceneSystems(Contexts contexts) : base("Scene Systems")
    {
        //Initialize Systems
        Add(new InitSceneSystem(contexts));

        //Reactive Systems
        Add(new SwitchSceneSystem(contexts));
        Add(new OpenUiSystem(contexts));
        Add(new CloseUiSystem(contexts));
        Add(new LoadPlayerSystem(contexts));
        Add(new MoveMainCameraSystem(contexts));

        //Cleanup Systems
    }
}