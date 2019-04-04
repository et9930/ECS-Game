using System.Collections.Generic;
using Entitas;

public class OpenUiSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public OpenUiSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var layerConfig = _context.uiLayerConfig.config;
        _context.sceneService.instance.InitializeLayers(layerConfig);
        _context.uiLayerConfigEntity.isDestroy = true;

        _context.ReplaceUuidToEntity(new Dictionary<int, GameEntity>());
        _context.ReplaceUiChildList(new Dictionary<int, List<int>>());

        var e = _context.CreateEntity();
        e.ReplaceUiOpen("GameState");
        e.ReplaceName("GameState");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.UiOpen);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasUiOpen && entity.hasName;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var rootEntity = e;
            var id = e.hasParentEntity
                ? _context.sceneService.instance.OpenUI(e.name.text, e.uiOpen.prefabName,
                    _context.uiConfig.UiInfos[e.uiOpen.prefabName].UiLayer, _context, ref rootEntity,
                    e.parentEntity.value)
                : _context.sceneService.instance.OpenUI(e.name.text, e.uiOpen.prefabName,
                    _context.uiConfig.UiInfos[e.uiOpen.prefabName].UiLayer, _context, ref rootEntity);
            _context.uuidToEntity.dic[id] = rootEntity;
            _context.uiChildList.dic[id] = new List<int>();
            if (e.hasParentEntity && e.parentEntity.value.hasUiRootId)
            {
                _context.uiChildList.dic[e.parentEntity.value.uiRootId.value].Add(id);
            }

//            if (e.hasNinjutsuName)
//            {
//                rootEntity.ReplaceNinjutsuName(e.ninjutsuName.value);
//            }

            e.ReplaceUiRootId(id);
            e.RemoveUiOpen();
        }
    }
}