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
                case 1005:
                    ReceiveTowardControl(e.matchData.payload);
                    break;
                case 1006:
                    ReceiveMakeChaKuRaControl(e.matchData.payload);
                    break;
                case 1007:
                    ReceiveChaKuRaExpendControl(e.matchData.payload);
                    break;
                case 1008:
                    ReceiveTaiRyoKuCoastControl(e.matchData.payload);
                    break;
                case 1009:
                    ReceiveChangeWeaponControl(e.matchData.payload);
                    break;
                case 1010:
                    ReceiveThrowWeaponControl(e.matchData.payload);
                    break;
                    
            }

            _context.CreateEntity().ReplaceDebugMessage(e.matchData.dataCode + ": " + e.matchData.payload);
            e.isDestroy = true;
        }
    }

    private void ReceiveMovementControl(string payload)
    {
        _context.CreateEntity().ReplaceMovementControl(Utilities.ParseJson<MatchDataMovementControl>(payload));
    }

    private void ReceivePhysicsData(string payload)
    {
        var stateData = Utilities.ParseJson<MatchDataState>(payload);
        var player = _context.GetEntityWithId(stateData.userId);
        if (player == null) return;
        player.ReplaceAcceleration(stateData.acceleration);
        player.ReplaceVelocity(stateData.velocity);
        player.ReplacePosition(stateData.position);
        player.ReplaceChaKuRaCurrent(stateData.currentChaKuRa);
        player.ReplaceTaiRyoKuCurrent(stateData.currentTaiRyoKu);
        player.ReplaceHealthCurrent(stateData.currentHealth);
    }

    private void ReceiveJumpControl(string payload)
    {
        _context.CreateEntity().ReplaceJumpControl(Utilities.ParseJson<MatchDataJumpControl>(payload));
    }

    private void ReceiveNormalAttackControl(string payload)
    {
        _context.CreateEntity().ReplaceNormalAttackControl(Utilities.ParseJson<MatchDataNormalAttackControl>(payload));
    }

    private void ReceiveTowardControl(string payload)
    {
        var towardControl = Utilities.ParseJson<MatchDataTowardControl>(payload);
        var player = _context.GetEntityWithId(towardControl.userId);
        player?.ReplaceToward(towardControl.faceLeft);
    }

    private void ReceiveMakeChaKuRaControl(string payload)
    {
        var makeChaKuRaControl = Utilities.ParseJson<MatchDataMakeChaKuRaControl>(payload);
        var player = _context.GetEntityWithId(makeChaKuRaControl.userId);
        if (player == null) return;
        player.isMakingChaKuRa = makeChaKuRaControl.isMakingChaKuRa;
    }

    private void ReceiveChaKuRaExpendControl(string payload)
    {
        var chaKuRaExpendControl = Utilities.ParseJson<MatchDataChaKuRaExpendControl>(payload);
        var player = _context.GetEntityWithId(chaKuRaExpendControl.userId);
        player?.ReplaceChaKuRaExpend(chaKuRaExpendControl.chaKuRaExpend);
    }

    private void ReceiveTaiRyoKuCoastControl(string payload)
    {
        var taiRyoKuCoastControl = Utilities.ParseJson<MatchDataTaiRyuKuExpendControl>(payload);
        var player = _context.GetEntityWithId(taiRyoKuCoastControl.userId);
        player?.ReplaceTaiRyoKuExpend(taiRyoKuCoastControl.taiRyuKuExpend);
    }

    private void ReceiveChangeWeaponControl(string payload)
    {
        var useNinjaItemControl = Utilities.ParseJson<MatchDataUseNinjaItemControl>(payload);
        var player = _context.GetEntityWithId(useNinjaItemControl.userId);
        player?.ReplaceUseNinjaItem(useNinjaItemControl.item);
    }

    private void ReceiveThrowWeaponControl(string payload)
    {
        var throwWeaponControl = Utilities.ParseJson<MatchDataThrowWeaponControl>(payload);
        var player = _context.GetEntityWithId(throwWeaponControl.userId);
        if(player == null) return;
        player.isTryThrowWeapon = true;
    }
}