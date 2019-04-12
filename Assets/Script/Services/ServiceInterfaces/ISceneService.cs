using System.Collections.Generic;
using System.Numerics;

public interface ISceneService
{
    void InitializeLayers(UiLayerInfos uiLayerInfos);
    void OpenScene(string sceneName, GameContext context);
    IEnumerable<float> OpenSceneAsync(string sceneName, GameContext context);
    int OpenUI(string uiName, string prefabName, string layer, GameContext context, ref GameEntity rootEntity, GameEntity parentEntity = null);
    void CloseUI(int id);
    void AllowSceneActive(bool active);
    Vector3 MainCameraPosition { get; set; }
    Vector2 GetUILocalPosition(string uiName);
    void SetUILocalPosition(string uiName, Vector2 position);
    Vector2 GetUIAnchoredPosition(string uiName);
    void SetUIAnchoredPosition(string uiName, Vector2 position);
    void SetUIAnchorMax(string uiName, Vector2 anchorMax);
    void SetUIAnchorMin(string uiName, Vector2 anchorMin);
    float GetUIAlpha(string uiName);
    void SetUIAlpha(string uiName, float value);
    float GetUIAngle(string uiName);
    void SetUIAngle(string uiName, float value);
    void SetParent(int child, string parent);
    string GetInputValue(string uiName);
    void SetInputValue(string uiName, string value);
    bool GetToggleOnState(string uiName);
    void SetToggleOnState(string uiName, bool state);
    int GetDropdownValue(string uiName);
    void SetDropdownValue(string uiName, int value);
    void SetSelectableInteractable(string uiName, bool value);
}
