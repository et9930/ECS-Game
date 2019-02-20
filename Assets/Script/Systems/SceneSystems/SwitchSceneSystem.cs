using System.Collections;
using System.Collections.Generic;
using Entitas;

public class SwitchSceneSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    private readonly GameContext _context;

    public SwitchSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceCurrentScene("LaunchScene");
        _context.ReplaceLoadScene("BattleScene");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LoadScene);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLoadScene && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.coroutineService.instance.StartCoroutine(SwitchScene(e.loadScene.name));
            e.isDestroy = true;
        }
    }

    private IEnumerator SwitchScene(string sceneName)
    {
        float displayProgress = 0.0f;

        // open loading scene
        _context.sceneService.instance.OpenScene("LoadingScene", _context);
        _context.ReplaceCurrentScene("LoadingScene");
        yield return _context.coroutineService.instance.WaitForEndOfFrame();
        GameEntity loadingProcessRootEntity = _context.CreateEntity();
        var loadingProcessUiId = _context.sceneService.instance.OpenUI("LoadingProcess", "TopLayer", _context, ref loadingProcessRootEntity);
        loadingProcessRootEntity.ReplaceActive(false);
        _context.uuidToEntity.dic[loadingProcessUiId] = loadingProcessRootEntity;
        _context.ReplaceLoadingSceneProcess(0.0f);
        var randomImage = _context.loadingUiRandomInfo.RandomImages[Utilities.RandomInt(0, _context.loadingUiRandomInfo.RandomImages.Count)];
        var randomText = _context.loadingUiRandomInfo.RandomTexts[Utilities.RandomInt(0, _context.loadingUiRandomInfo.RandomTexts.Count)];
        _context.ReplaceLoadingSceneTextImage(randomText.Title, randomText.Text, randomImage.Path);
        yield return _context.coroutineService.instance.WaitForEndOfFrame();
        loadingProcessRootEntity.ReplaceActive(true);
        
        // clean old scene


        // load new scene
        foreach (var value in _context.sceneService.instance.OpenSceneAsync(sceneName, _context))
        {
            if (value >= 0.9f)
            {
                break;
            }
            while (displayProgress < value * 5 / 9)
            {
                
                displayProgress += 0.01f;
                _context.ReplaceLoadingSceneProcess(displayProgress);
                yield return _context.coroutineService.instance.WaitForEndOfFrame();
            }
            yield return _context.coroutineService.instance.WaitForEndOfFrame();
        }

        // open ui
        var uis = _context.sceneConfig.dic[sceneName].Uis;
        for(var i = 0; i < uis.Count; i++)
        {
            var ui = _context.CreateEntity();
            ui.isUiOpen = true;
            ui.ReplaceName(uis[i]);
            while (displayProgress < 0.5f + ((0.4f / uis.Count)* i))
            {
                displayProgress += 0.01f;
                _context.ReplaceLoadingSceneProcess(displayProgress);
                yield return _context.coroutineService.instance.WaitForEndOfFrame();
            }
        }

        while (displayProgress < 0.99f)
        {
            displayProgress += 0.01f;
            _context.ReplaceLoadingSceneProcess(displayProgress);
            yield return _context.coroutineService.instance.WaitForEndOfFrame();
        }

        // close loading scene
        _context.uuidToEntity.dic[loadingProcessUiId].isUiClose = true;
        _context.ReplaceLoadingSceneProcess(0.0f);
        _context.loadingSceneProcessEntity.isDestroy = true;
        _context.loadingSceneTextImageEntity.isDestroy = true;

        // switch to new scene
        _context.sceneService.instance.AllowSceneActive(true);
        _context.ReplaceCurrentScene(sceneName);
    }
}