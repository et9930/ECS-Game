using System;
using System.Collections.Generic;
using Entitas;

public class ClearBattleSceneSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public ClearBattleSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadScene);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadScene && entity.loadScene.name != "BattleScene" && !entity.isDestroy && _context.currentScene.name == "BattleScene";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.CreateEntity().ReplaceDebugMessage("ClearBattleSceneSystem");

            // close view
            foreach (var view in _context.GetGroup(GameMatcher.View))
            {
                view.isDeleteView = true;
            }

            // clear unique component
            _context.RemoveBattleOver();
            _context.ReplaceBattleValueDisplayNumber(0);
            _context.ReplaceCurrentCollisionEntity(new Dictionary<string, List<string>>());
            _context.ReplaceYinFreeze(false, false, false, false, false, false, false);
            _context.ReplaceCurrentInNumber(0);
            _context.RemoveCurrentMapName();
            _context.RemoveCurrentMatchData();
            if (_context.isReplaying)
            {
                _context.RemoveCurrentReplayData();
            }
            _context.isGameMatched = false;
            _context.isJumpForceIncreasing = false;
            _context.isJumpFreezing = false;
            _context.ReplaceJutsuSelectTargetId(0);
            _context.ReplaceLastMovementKeyState(0.0f, 0.0f);
            _context.ReplaceLastSendStateTime(0.0f);
            _context.ReplaceMakeYinTime(3.0f);
            _context.isMatchStart = false;
            _context.isNinjaItemMenuOpen = false;
            _context.isNinjaItemMenuOpenFreezing = false;
            _context.isNinjutsuMenuOpen = false;
            _context.isNinjutsuMenuOpenFreezing = false;
            _context.ReplacePerceptionHTC(new Dictionary<string, GameEntity>());
            _context.ReplacePerceptionPositionExist(new Dictionary<string, GameEntity>());
            _context.ReplacePerceptionPositionAccurate(new Dictionary<string, GameEntity>());
            if (_context.hasPointNinjaItemMenuItem)
            {
                _context.RemovePointNinjaItemMenuItem();
            }
            if (_context.hasPointNinjutsuMenuItem)
            {
                _context.RemovePointNinjutsuMenuItem();
            }
            _context.isQuickActionMenuOn = false;
            _context.isSearchingBattle = false;
            _context.isAllPlayerJoined = false;
            if (_context.isReplaying)
            {
                _context.RemoveReplayStartTime();
            }
            _context.isTaijutsuAttackFreezing = false;
            _context.ReplaceThrowWeaponNumber(0);
            _context.isTryThrowWeaponFreezing = false;
            _context.isReplaying = false;
        }
    }
}