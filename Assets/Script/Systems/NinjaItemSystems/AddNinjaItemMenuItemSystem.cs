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
            var ninjaItems = _context.characterBaseAttributes.dic[e.loadPlayer.playerName].ninjaItemList;

            var i = 0;

            e.ReplaceNinjaItemList(new Dictionary<string, GameEntity>());

            foreach (var config in ninjaItems)
            {
                var item = _context.CreateEntity();
                foreach (var ui in _context.GetGroup(GameMatcher.UiRootId))
                {
                    if (!ui.hasName) continue;
                    if (ui.name.text != "NinjaItemMenuItem" + i) continue;

                    item.ReplaceParentEntity(ui);
                    break;
                }
                item.ReplaceUiOpen("NinjaItemMenuItem");
                item.ReplaceNinjaItemName(config.Key);
                item.ReplaceName("NinjaItemMenuItem");
                item.ReplaceLeftNumber(config.Value);
                i++;

                e.ninjaItemList.dic[config.Key] = item;
            }

        }
    }
}
