using System.Collections.Generic;
using System.ComponentModel;
using Entitas;

public class CloseUiSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public CloseUiSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiClose);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isUiClose && entity.hasUiRootId;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            CloseUi(e.uiRootId.value);
        }
    }

    private void CloseUi(int rootId)
    {
//        if (_context.uiChildList.dic.ContainsKey(rootId))
//        {
//            foreach (var childId in _context.uiChildList.dic[rootId])
//            {
//                CloseUi(childId);
//            }
//        }

        _context.CreateEntity().ReplaceDebugMessage("Close " + _context.uuidToEntity.dic[rootId].name.text);


        foreach (var uiEntity in _context.GetEntities(GameMatcher.UiRootId))
        {
            if (uiEntity.uiRootId.value == rootId)
            {
                uiEntity.isDestroy = true;
            }
        }
        _context.sceneService.instance.CloseUI(rootId);
        _context.uuidToEntity.dic.Remove(rootId);
//        _context.uiChildList.dic.Remove(rootId);
    }
}