public interface ISceneService
{
    void InitializeLayers(UiLayerInfos uiLayerInfos);
    void SwitchScene(string sceneName, string[] uiNameList, GameContext context);
    int OpenUI(string uiName, string layer, GameContext context);
    void CloseUI(int id);
}
