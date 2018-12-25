public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterLogServiceSystem(contexts, services.Log));
        Add(new RegisterViewServiceSystem(contexts, services.View));
        Add(new RegisterMouseInputServiceSystem(contexts, services.MouseInput));
        Add(new RegisterLoadConfigServiceSystem(contexts, services.LoadConfig));
        Add(new RegisterUiServiceSystem(contexts, services.scene));
    }
}