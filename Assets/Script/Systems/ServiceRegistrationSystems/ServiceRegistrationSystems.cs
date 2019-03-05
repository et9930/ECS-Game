public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterLogServiceSystem(contexts, services.Log));
        Add(new RegisterViewServiceSystem(contexts, services.View));
        Add(new RegisterMouseInputServiceSystem(contexts, services.MouseInput));
        Add(new RegisterLoadConfigServiceSystem(contexts, services.LoadConfig));
        Add(new RegisterUiServiceSystem(contexts, services.Scene));
        Add(new RegisterCoroutineServiceSystem(contexts, services.Coroutine));
        Add(new RegisterKeyInputServiceSystem(contexts, services.KeyInput));
        Add(new RegisterTimeServiceSystem(contexts, services.Time));
        Add(new RegisterPhysicsServiceSystem(contexts, services.Physics));
    }
}