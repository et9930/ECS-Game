using System.Numerics;

public interface IPhysicsService
{
    void InitializePhysicsShapeData(GameContext context);
    bool CheckCollision(GameEntity entity1, GameEntity entity2);
    void UpdateBoxCollision(GameEntity e, Vector2 size, Vector2 offset);
}