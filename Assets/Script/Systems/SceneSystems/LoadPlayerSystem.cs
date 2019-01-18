using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class LoadPlayerSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    
    public LoadPlayerSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadPlayer);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadPlayer && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var newPlayer = _context.CreateEntity();
            newPlayer.ReplacePlayerId(e.loadPlayer.playerId);
            newPlayer.ReplaceName(e.loadPlayer.playerName);
//            _context.coroutineService.instance.StartCoroutine(LoadPlayer(newPlayer));

            newPlayer.ReplaceSprite(_context.imageAsset.imageInfos.infos[0].animationInfos[0].frameInfos[0].path);
            newPlayer.ReplacePosition(Vector3.Zero);
            newPlayer.ReplaceScale(new Vector2(1.5f, 1.5f));

            newPlayer.isInitializePhysical = true;

            newPlayer.isAffectedByGravity = true;
            newPlayer.isOnTheGround = true;
            e.isDestroy = true;
        }
    }

//    private IEnumerator LoadPlayer(GameEntity newPlayer)
//    {
//        
//
//    }

}