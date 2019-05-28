using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class SendThrowWeaponControlSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;


    public SendThrowWeaponControlSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TryThrowWeapon);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isTryThrowWeapon;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.hasBattleOver) return;

        if (_context.isReplaying) return;

        foreach (var e in entities)
        {
            if (e.isDead) continue;
            if (e.hasCurrentWeapon)
            {
                SetControlInfo(e);
            }

            e.isTryThrowWeapon = false;
        }
    }

    private async void SetControlInfo(GameEntity player)
    {
        var payload = await _context.networkService.instance.RpcCall("rpc_get_uuid", null, true);
        if (payload == null) return;

        var getUuid = Utilities.ParseJson<SCGetUuid>(payload);

        var newThrowWeaponControl = new MatchDataThrowWeaponControl
        {
            userId = player.id.value,
            weaponName = player.currentWeapon.value,
            weaponId = getUuid.uuid,
            hierarchy = player.hierarchy.value,
            left = player.toward.left,
            position = player.position.value
        };

        _context.CreateEntity().ReplaceSendMatchData(1010, Utilities.ToJson(newThrowWeaponControl));
    }
}