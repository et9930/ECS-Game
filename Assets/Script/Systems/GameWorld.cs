public class GameWorld : Feature
{
    public GameWorld(Contexts contexts, Services services) : base("Game World")
    {
        Add(new ServiceRegistrationSystems(contexts, services));
        Add(new GameEventSystems(contexts));

        Add(new AnimationSystems(contexts));
        Add(new DisplaySystems(contexts));
        Add(new InputSystems(contexts));
        Add(new LogSystems(contexts));        
        Add(new NetworkSystems(contexts));
        Add(new SceneSystems(contexts));
        
        Add(new DamageSystems(contexts));
        Add(new HTCSystems(contexts));
        Add(new NinjutsuSystems(contexts));
        Add(new PerceptionSystems(contexts));
        Add(new TaijutsuSystems(contexts));
        Add(new WeaponSystems(contexts));

        Add(new DestroySystems(contexts));
    }
}