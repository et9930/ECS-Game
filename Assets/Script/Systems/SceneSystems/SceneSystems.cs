﻿public class SceneSystems : Feature
{
    public SceneSystems(Contexts contexts) : base("Scene Systems")
    {
        //Reactive Systems
        Add(new SwitchSceneSystem(contexts));

        //Cleanup Systems
    }
}