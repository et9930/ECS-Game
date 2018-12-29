using System.Collections;
using System.Collections.Generic;

public interface ISceneService
{
    void InitializeLayers(UiLayerInfos uiLayerInfos);
    void OpenScene(string sceneName, GameContext context);
    IEnumerable<float> OpenSceneAsync(string sceneName, GameContext context);
    int OpenUI(string uiName, string layer, GameContext context, ref GameEntity rootEntity);
    void CloseUI(int id);
    void AllowSceneActive(bool active);
}
