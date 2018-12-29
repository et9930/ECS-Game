public interface IPhysicsService
{
    // Effector
    void AddAreaEffector(GameContext context, GameEntity entity);
    void AddBuoyancyEffector(GameContext context, GameEntity entity);
    void AddPlatformEffector(GameContext context, GameEntity entity);
    void AddPointEffector(GameContext context, GameEntity entity);
    void AddSurfaceEffector(GameContext context, GameEntity entity);
    void RemoveEffector(GameContext context, GameEntity entity);

    // 
}