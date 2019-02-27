using System.Collections.Generic;
using Entitas;

public class AddNinjaItemMenuItemSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public AddNinjaItemMenuItemSystem(Contexts contexts) : base(contexts.game)
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
            GameEntity itemList = null;

            foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
            {
                if (ui.name.text != "NinjaItemMenuList") continue;

                itemList = ui;
                break;
            }

            if (itemList == null) continue;

            var ninjaItems = _context.characterBaseAttributes.dic[e.loadPlayer.playerName].ninjaItemList;

            for (var i = 0; i < ninjaItems.Count; i++)
            {
                var itemEntity = _context.CreateEntity();
                itemEntity.ReplaceName("NinjaItemMenuItem");
                itemEntity.ReplaceNinjaItemName(ninjaItems[i]);
                foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                {
                    if (ui.name.text != "NinjaItemMenuItem" + i) continue;

                    itemEntity.ReplaceParentEntity(ui);
                    break;
                }
                itemEntity.ReplaceUiOpen("NinjaItemMenuItem");
            }
        }
    }
}
