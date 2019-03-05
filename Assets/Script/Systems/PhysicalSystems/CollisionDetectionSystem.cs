using System;
using System.Collections.Generic;
using Entitas;

public class CollisionDetectionSystem : IExecuteSystem, IInitializeSystem
{
    private readonly GameContext _context;

    public CollisionDetectionSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.physicsService.instance.InitializePhysicsShapeData(_context);
    }

    public void Execute()
    {
        foreach (var collisionPair in _context.collisionPairConfig.list)
        {
            foreach (var firstEntity in _context.GetEntitiesWithTag(collisionPair.first))
            {
                if (!firstEntity.isMoving) continue;
                if (!firstEntity.hasSprite || !firstEntity.hasBoundingBox || !firstEntity.hasName) continue;

                foreach (var secondEntity in _context.GetEntitiesWithTag(collisionPair.second))
                {
                    if (!secondEntity.hasSprite || !secondEntity.hasBoundingBox || !secondEntity.hasName) continue;

                    if (firstEntity.boundingBox.minX > secondEntity.boundingBox.maxX) continue;
                    if (firstEntity.boundingBox.maxX < secondEntity.boundingBox.minX) continue;
                    if (firstEntity.boundingBox.minY > secondEntity.boundingBox.maxY) continue;
                    if (firstEntity.boundingBox.maxY < secondEntity.boundingBox.minY) continue;
                    if (firstEntity.boundingBox.minZ > secondEntity.boundingBox.maxZ) continue;
                    if (firstEntity.boundingBox.maxZ < secondEntity.boundingBox.minZ) continue;

                    var hasCollision = _context.physicsService.instance.CheckCollision(firstEntity, secondEntity);
                    if (hasCollision)
                    {
                        _context.CreateEntity().ReplaceDebugMessage(firstEntity.name.text + " and " + secondEntity.name.text + " has collision");
                    }
                }
            }
        }
    }


}