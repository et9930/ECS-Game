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
        Add(new FrictionalSystem(contexts));
        Add(new VelocitySystem(contexts));
        Add(new BoundingBoxPositionSystem(contexts));
        Add(new CollisionDetectionSystem(contexts));
        Add(new AddPhysicalComponentSystem(contexts));
    }
}