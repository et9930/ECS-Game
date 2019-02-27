using System;
using System.Collections.Generic;
using System.Numerics;
using Entitas;

public class AddNinjutsuMenuItemSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddNinjutsuMenuItemSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadPlayer);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadPlayer && entity.loadPlayer.playerId == _context.currentPlayerId.value;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            GameEntity menuContent = null;
            GameEntity menuScrollRect = null;
            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjutsuMenuContent") continue;
                menuContent = ui;
                break;
            }

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjutsuMenuScrollRect") continue;
                menuScrollRect = ui;
                break;
            }

            if (menuContent == null || menuScrollRect == null) continue;

            foreach (var ninjutsuName in _context.characterBaseAttributes.dic[e.loadPlayer.playerName].ninjutsuList)
            {
                var itemEntity = _context.CreateEntity();
                itemEntity.ReplaceName("NinjutsuMenuItem");
                itemEntity.ReplaceNinjutsuName(ninjutsuName);
                itemEntity.ReplaceParentEntity(menuContent);
                itemEntity.ReplaceUiOpen("NinjutsuMenuItem");
            }

            var height = _context.characterBaseAttributes.dic[e.loadPlayer.playerName].ninjutsuList.Count * 40.0f;
            if (height < 720.0f)
            {
                height = 720.0f;
            }
            menuScrollRect.ReplaceSize(new Vector2(32.5f, height));
        }
    }
}
