public interface IPhysicsService
{
    void InitializePhysicsShapeData(GameContext context);
    bool CheckCollision(GameEntity entity1, GameEntity entity2);
}