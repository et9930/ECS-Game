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
            var characterBaseAttributes = _context.characterBaseAttributes.dic[e.loadPlayer.playerName];

            e.ReplaceId(e.loadPlayer.playerId);
            e.ReplaceName(e.loadPlayer.playerName);
            e.ReplaceAnimation("idle", false);
            e.ReplaceHierarchy(0);
            e.ReplacePosition(_context.mapConfig.list[_context.currentMapName.value].CharacterInPosition[0]);
            e.ReplaceRotation(Vector3.Zero);
            e.ReplaceScale(new Vector2(1.0f, 1.0f));
            e.ReplaceMass(66.5f);
            e.ReplaceToward(false);

            e.ReplaceHealthTotal(characterBaseAttributes.baseHealth);
            e.ReplaceHealthRecoverable(characterBaseAttributes.baseHealth);
            e.ReplaceHealthRecoverSpeed(0.1f);
            e.ReplaceHealthCurrent(characterBaseAttributes.baseHealth);

            e.ReplaceChaKuRaTotal(characterBaseAttributes.baseChaKuRa);
            e.ReplaceChaKuRaCurrent(characterBaseAttributes.baseChaKuRa);
            e.ReplaceChaKuRaSlewRate(characterBaseAttributes.chaKuRaSlewRate);

            e.ReplaceTaiRyoKuCurrent(characterBaseAttributes.baseTaiRyoKu);
            e.ReplaceTaiRyoKuTotal(characterBaseAttributes.baseTaiRyoKu);
            e.ReplaceTaiRyoKuTired(characterBaseAttributes.tiredTaiRyoKu);
            e.ReplaceTaiRyoKuDeath(characterBaseAttributes.deathTaiRyoKu);
            e.ReplaceTaiRyoKuRecoverSpeed(0.1f);

            e.ReplacePerceptionLevel(characterBaseAttributes.perceptionLevel);
            e.ReplaceAntiPerceptionLevel(characterBaseAttributes.antiPerceptionLevel);

            e.isInitializePhysical = true;
            e.isAffectedByGravity = true;
            e.ReplaceOnTheGround(false);
            e.isNormalAttacking = true;
            e.isAddShadow = true;
            e.ReplaceYinList(new List<Yin>());
            e.ReplaceTag("Character");
            e.ReplaceBoundingBox(0,0,0,0,0,0);

            e.RemoveLoadPlayer();
            e.isQuickActionObject = true;

            var currentWeaponIcon = _context.CreateEntity();
            currentWeaponIcon.ReplaceName("CurrentWeaponIcon_" + e.name.text);
            currentWeaponIcon.ReplaceParentEntity(e);
            currentWeaponIcon.ReplaceUiExcursion(new Vector2(60, 200));
            currentWeaponIcon.ReplaceUiOpen("CurrentWeaponIcon");
        }
    }

}