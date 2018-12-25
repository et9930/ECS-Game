using System.Collections.Generic;
using Assets.Script.Controllers.UnityController;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnitySceneService : ISceneService
{
    private Dictionary<string, GameObject> _uiLayers = new Dictionary<string, GameObject>();
    private Dictionary<int, GameObject> _uiDictionary = new Dictionary<int, GameObject>();
    private GameObject _layersRoot;

    public void InitializeLayers(UiLayerInfos uiLayerInfos)
    {
        _layersRoot = new GameObject("UILayerRoot");
        Object.DontDestroyOnLoad(_layersRoot);
        foreach (var uiLayerInfo in uiLayerInfos.UILayers)
        {
            // create game object
            var layerGameObject = new GameObject(uiLayerInfo.Name);
            layerGameObject.transform.SetParent(_layersRoot.transform);
            layerGameObject.layer = 5;

            // create canvas
            var canvas = layerGameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;
            canvas.planeDistance = uiLayerInfo.PlaneDistance;
            canvas.sortingLayerName = "UI";
            canvas.sortingOrder = uiLayerInfo.OrderInLayer;

            // create canvas scaler
            var scaler = layerGameObject.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            scaler.referenceResolution = new Vector2(1920, 1080);

            // create graphic raycaster
            layerGameObject.AddComponent<GraphicRaycaster>();

            _uiLayers[uiLayerInfo.Name] = layerGameObject;
        }
    }

    public void SwitchScene(string sceneName, string[] uiNameList, GameContext context)
    {
        SceneManager.LoadScene("LoadingScene");
        OpenUI("LoadingProcess", "TopLayer", context);
        


    }

    public int OpenUI(string uiName, string layer, GameContext context)
    {
        var uiGo = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/UI/" + uiName));
        var rectTransform = uiGo.GetComponent<RectTransform>();
        var uiInstanceId = uiGo.GetInstanceID();

        uiGo.name = uiName;
        uiGo.transform.SetParent(_uiLayers[layer].transform);
        uiGo.transform.localScale = Vector3.one;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.anchoredPosition3D = Vector3.zero;

        _uiDictionary[uiInstanceId] = uiGo;

        OpenComponents(uiName, context, uiGo, uiInstanceId);

        return uiInstanceId;
    }

    private void OpenComponents(string uiName, GameContext context, GameObject uiGo, int uiInstanceId)
    {
        var componentInfo = context.uiConfig.UiInfos[uiName];
        foreach (var component in componentInfo.Components)
        {
            var e = context.CreateEntity();
            e.AddName(component.ComponentName);
            e.AddUiRootId(uiInstanceId);
            GameObject componentGo = null;
            if (component.ComponentType == "Text")
            {
                componentGo = OpenTextComponent(uiName, context, uiGo, e, component);
            }

            if (componentGo != null)
            {
                var eventListeners = componentGo.GetComponents<IEventListener>();
                foreach (var listener in eventListeners)
                {
                    listener.RegisterListeners(e);
                }
            }
        }
    }

    private GameObject OpenTextComponent(string uiName, GameContext context, GameObject uiGo, GameEntity e, ComponentInfo component)
    {
        e.AddText("ECS-Game");
        var gameObject = uiGo.transform.Find(component.ComponentPath.Substring(uiName.Length + 1)).gameObject;
        var textController = gameObject.AddComponent<UnityTextController>();
        textController.InitializeComponent(context, e);
        gameObject.AddComponent<TextListener>();
        return gameObject;
    }

    public void CloseUI(int id)
    {
        GameObject.Destroy(_uiDictionary[id]);
    }


}