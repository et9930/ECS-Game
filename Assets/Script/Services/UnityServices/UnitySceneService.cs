using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UnitySceneService : ISceneService
{
    private Dictionary<string, GameObject> _uiLayers = new Dictionary<string, GameObject>();
    private Dictionary<int, GameObject> _uiDictionary = new Dictionary<int, GameObject>();
    private GameObject _layersRoot;
    private AsyncOperation _openSceneOperation;

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

    public void OpenScene(string sceneName, GameContext context)
    {
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerable<float> OpenSceneAsync(string sceneName, GameContext context)
    {
        _openSceneOperation = null;
        _openSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        _openSceneOperation.allowSceneActivation = false;
        
        while (_openSceneOperation.progress < 0.9)
        {
            yield return _openSceneOperation.progress;
        }
        yield return 0.9f;

    }

    public void AllowSceneActive(bool active)
    {
        _openSceneOperation.allowSceneActivation = active;
    }

    public void MoveMainCamera(System.Numerics.Vector3 position)
    {
        Camera.main.transform.position = Utilities.ToUnityEngineVector3(position);
    }

    public int OpenUI(string uiName, string layer, GameContext context, ref GameEntity rootEntity)
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

        OpenChildren(uiName, context, uiGo, uiInstanceId, ref rootEntity);

        return uiInstanceId;
    }

    private void OpenChildren(string uiName, GameContext context, GameObject uiGo, int uiInstanceId, ref GameEntity rootEntity)
    {
        var componentInfo = context.uiConfig.UiInfos[uiName];
        foreach (var component in componentInfo.Components)
        {
            var e = context.CreateEntity();
            e.AddName(component.ComponentName);
            e.AddUiRootId(uiInstanceId);
            
            GameObject componentGo;
            if (uiName == component.ComponentPath)
            {
                componentGo = uiGo;
                rootEntity = e;
            }
            else
            {
                componentGo = uiGo.transform.Find(component.ComponentPath.Substring(uiName.Length + 1)).gameObject;
            }

            foreach (var listener in component.Listener)
            {
                componentGo.AddComponent(ListenerList.dictionary[listener]);
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

    public void CloseUI(int id)
    {
        GameObject.Destroy(_uiDictionary[id]);
    }

    
}