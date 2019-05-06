using System;
using System.Collections.Generic;
using Entitas;

public class ReceiveMatchDataSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ReceiveMatchDataSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MatchData);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMatchData && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            switch (e.matchData.dataCode)
            {
                case 1001:
                    ReceiveMovementControl(e.matchData.payload);
                    break;
                case 1002:
                    ReceivePhysicsData(e.matchData.payload);
                    break;
                case 1003:
                    ReceiveJumpControl(e.matchData.payload);
                    break;
                case 1004:
                    ReceiveNormalAttackControl(e.matchData.payload);
                    break;
            }

            _context.CreateEntity().ReplaceDebugMessage(e.matchData.payload);
            e.isDestroy = true;
        }
    }

    private void ReceiveMovementControl(string payload)
    {
        _context.CreateEntity().ReplaceMovementControl(Utilities.ParseJson<MatchDataMovementControl>(payload));
    }

    private void ReceivePhysicsData(string payload)
    {
        var physicsData = Utilities.ParseJson<MatchDataPhysics>(payload);
        var player = _context.GetEntityWithId(physicsData.userId);
        if (player == null) return;
        player.ReplaceAcceleration(physicsData.acceleration);
        player.ReplaceVelocity(physicsData.velocity);
        player.ReplacePosition(physicsData.position);
    }

    private void ReceiveJumpControl(string payload)
    {
        _context.CreateEntity().ReplaceJumpControl(Utilities.ParseJson<MatchDataJumpControl>(payload));
    }

    private void ReceiveNormalAttackControl(string payload)
    {
        _context.CreateEntity().ReplaceNormalAttackControl(Utilities.ParseJson<MatchDataNormalAttackControl>(payload));
    }

}