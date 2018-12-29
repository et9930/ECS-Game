public class PhysicalSystems : Feature
{
    public PhysicalSystems(Contexts contexts) : base("Physical Systems")
    {
        // Initialize Systems
        Add(new InitPhysicalConstantSystem(contexts));

        // Reactive Systems
        Add(new GravitySystem(contexts));
        Add(new AntiGravitySystem(contexts));

        Add(new AddForceSystem(contexts));

        Add(new AccelerationSystem(contexts));

        Add(new VelocitySystem(contexts));
    }
}