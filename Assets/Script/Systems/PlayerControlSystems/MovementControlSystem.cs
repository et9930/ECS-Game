using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;
using Nakama.TinyJson;

public class MovementControlSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public MovementControlSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MovementControl);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMovementControl && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var player = _context.GetEntityWithId(e.movementControl.data.userId);
            if (player == null) continue;
            if (e.movementControl.data.horizontal != 0.0f || e.movementControl.data.vertical != 0.0f)
            {
                player.isMoving = true;
                if(player.currentAnimation.name == "idle")
                    player.ReplaceAnimation("move", true);
                        
            }
            else
            {
                player.isMoving = false;
                if(player.currentAnimation.name == "move")
                    player.ReplaceAnimation("idle", true);
            }
            
            var tmpHorizontal = e.movementControl.data.horizontal * _context.characterBaseAttributes.dic[player.name.text].baseVelocity;
            var tmpVertical = e.movementControl.data.vertical * _context.characterBaseAttributes.dic[player.name.text].baseVelocity;
//            _context.CreateEntity().ReplaceDebugMessage("horizontal " + tmpHorizontal + ", vertical " + tmpVertical);
            player.ReplaceVelocity(new Vector3(tmpHorizontal, 0, tmpVertical));
            
            if (e.movementControl.data.horizontal > 0)
            {
                player.ReplaceToward(false);
            }
            else if (e.movementControl.data.horizontal < 0)
            {
                player.ReplaceToward(true);
            }

            e.isDestroy = true;
        }
    }
}