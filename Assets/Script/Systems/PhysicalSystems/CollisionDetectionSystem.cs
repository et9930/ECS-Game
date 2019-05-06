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
        _context.ReplaceCurrentCollisionEntity(new Dictionary<string, List<string>>());
    }

    public void Execute()
    {
        foreach (var collisionPair in _context.collisionPairConfig.list)
        {
            var checkedEntityList = new List<GameEntity>();
            foreach (var firstEntity in _context.GetEntitiesWithTag(collisionPair.first))
            {
//                if (!firstEntity.isMoving) continue;
                if (!firstEntity.hasSprite || !firstEntity.hasBoundingBox || !firstEntity.hasName) continue;

                if (!_context.currentCollisionEntity.dic.ContainsKey(firstEntity.id.value))
                {
                    _context.currentCollisionEntity.dic[firstEntity.id.value] = new List<string>();
                }

                foreach (var secondEntity in _context.GetEntitiesWithTag(collisionPair.second))
                {
                    if (!secondEntity.hasSprite || !secondEntity.hasBoundingBox || !secondEntity.hasName || firstEntity == secondEntity) continue;
                    if (checkedEntityList.Contains(secondEntity)) return;

                    if (CheckBoundingBox(firstEntity, secondEntity))
                    {
                        if (_context.currentCollisionEntity.dic[firstEntity.id.value].Contains(secondEntity.id.value)) continue;

                        _context.currentCollisionEntity.dic[firstEntity.id.value].Add(secondEntity.id.value);
                        _context.CreateEntity().ReplaceDebugMessage(firstEntity.name.text + " and " + secondEntity.name.text + " has collision");
                    }
                    else
                    {
                        if (!_context.currentCollisionEntity.dic[firstEntity.id.value].Contains(secondEntity.id.value)) continue;

                        _context.currentCollisionEntity.dic[firstEntity.id.value].Remove(secondEntity.id.value);
                        _context.CreateEntity().ReplaceDebugMessage(firstEntity.name.text + " and " + secondEntity.name.text + " leave collision");

                    }
                    //                    var hasCollision = _context.physicsService.instance.CheckCollision(firstEntity, secondEntity);
                    //                    if (hasCollision)
                    //                    {
                    //                    }
                }

                checkedEntityList.Add(firstEntity);
            }
        }
    }

    private bool CheckBoundingBox(GameEntity firstEntity, GameEntity secondEntity)
    {
        // no collision
        if (firstEntity.boundingBox.minX > secondEntity.boundingBox.maxX) return false;
        if (firstEntity.boundingBox.maxX < secondEntity.boundingBox.minX) return false;
        if (firstEntity.boundingBox.minY > secondEntity.boundingBox.maxY) return false;
        if (firstEntity.boundingBox.maxY < secondEntity.boundingBox.minY) return false;
        if (firstEntity.boundingBox.minZ > secondEntity.boundingBox.maxZ) return false;
        if (firstEntity.boundingBox.maxZ < secondEntity.boundingBox.minZ) return false;

        return true;
    }
}