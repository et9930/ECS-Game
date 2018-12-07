public class DestroySystems : Feature {
    public DestroySystems(Contexts contexts) : base("Destroy System")
    {
        Add(new DestroyNoGameObjectEntitySystem(contexts));
    }
	
}