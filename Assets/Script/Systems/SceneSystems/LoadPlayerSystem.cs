﻿using System.Collections;
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

            var newPlayer = _context.CreateEntity();
            newPlayer.ReplaceId(e.loadPlayer.playerId);
            newPlayer.ReplaceName(e.loadPlayer.playerName);
            newPlayer.ReplaceAnimation("idle", false);
            newPlayer.ReplaceHierarchy(0);
            newPlayer.ReplacePosition(_context.mapConfig.list.list[_context.currentMapName.value].CharacterInPosition[0]);
            newPlayer.ReplaceScale(new Vector2(1.0f, 1.0f));
            newPlayer.ReplaceMass(66.5f);
            newPlayer.ReplaceToward(false);

            newPlayer.ReplaceHealthTotal(characterBaseAttributes.baseHealth);
            newPlayer.ReplaceHealthRecoverable(characterBaseAttributes.baseHealth);
            newPlayer.ReplaceHealthRecoverSpeed(0.1f);
            newPlayer.ReplaceHealthCurrent(characterBaseAttributes.baseHealth);

            newPlayer.ReplaceChaKuRaTotal(characterBaseAttributes.baseChaKuRa);
            newPlayer.ReplaceChaKuRaCurrent(characterBaseAttributes.baseChaKuRa);
            newPlayer.ReplaceChaKuRaSlewRate(characterBaseAttributes.chaKuRaSlewRate);

            newPlayer.ReplaceTaiRyoKuCurrent(characterBaseAttributes.baseTaiRyoKu);
            newPlayer.ReplaceTaiRyoKuTotal(characterBaseAttributes.baseTaiRyoKu);
            newPlayer.ReplaceTaiRyoKuTired(characterBaseAttributes.tiredTaiRyoKu);
            newPlayer.ReplaceTaiRyoKuDeath(characterBaseAttributes.deathTaiRyoKu);
            newPlayer.ReplaceTaiRyoKuRecoverSpeed(0.1f);

            newPlayer.ReplaceAntiPerceptionLevel(characterBaseAttributes.antiPerceptionLevel);

            newPlayer.isInitializePhysical = true;
            newPlayer.isAffectedByGravity = true;
            newPlayer.ReplaceOnTheGround(false);
            newPlayer.isNormalAttacking = true;
            newPlayer.isAddShadow = true;
            newPlayer.ReplaceYinList(new List<Yin>());
            newPlayer.ReplaceTag("Character");
            e.isDestroy = true;
        }
    }

}