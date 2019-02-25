using System.Collections.Generic;
using Entitas.Unity;
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
            scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
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

    public System.Numerics.Vector3 MainCameraPosition {
        get { return Utilities.ToSystemNumericsVector3(Camera.main.transform.position); }
        set { Camera.main.transform.position = Utilities.ToUnityEngineVector3(value); }
    }

    public System.Numerics.Vector2 GetUIPosition(string uiName)
    {
        var ui = GameObject.Find(uiName);
        return ui != null ? Utilities.ToSystemNumericsVector2(ui.transform.localPosition) : System.Numerics.Vector2.Zero;
    }

    public void SetUIPosition(string uiName, System.Numerics.Vector2 position)
    {
        var ui = GameObject.Find(uiName);
        if (ui == null) return;
        
        ui.transform.localPosition = Utilities.ToUnityEngineVector2(position);
    }

    public float GetUIAlpha(string uiName)
    {
        var ui = GameObject.Find(uiName);
        if (ui == null) return 0.0f;

        var canvasGroup = ui.GetComponent<CanvasGroup>();
        if (canvasGroup)
        {
            return canvasGroup.alpha;
        }

        return ui.activeSelf ? 1.0f : 0.0f;
    }

    public void SetUIAlpha(string uiName, float value)
    {
        var ui = GameObject.Find(uiName);
        if (ui == null) return;

        var canvasGroup = ui.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = ui.AddComponent<CanvasGroup>();
        }

        canvasGroup.alpha = value;
    }

    public int OpenUI(string uiName, string prefabName, string layer, GameContext context, ref GameEntity rootEntity, GameEntity parentEntity = null)
    {
        var prefab = Resources.Load<GameObject>("Prefab/UI/" + prefabName);
        var uiGo = GameObject.Instantiate(prefab);

        var rectTransform = uiGo.GetComponent<RectTransform>();
        var uiInstanceId = uiGo.GetInstanceID();

        if (uiName != null)
        {
            uiGo.name = uiName;
        }
        
        if (parentEntity != null && parentEntity.hasUiRootId)
        {
            var parentUI = _uiDictionary[parentEntity.uiRootId.value].transform.Find(parentEntity.name.text);
            uiGo.transform.SetParent(parentUI);
        }
        else
        {
            uiGo.transform.SetParent(_uiLayers[layer].transform);
        }
        uiGo.transform.localScale = Vector3.one;
//        rectTransform.offsetMax = Vector2.zero;
//        rectTransform.offsetMin = Vector2.zero;
        rectTransform.anchoredPosition3D = prefab.GetComponent<RectTransform>().anchoredPosition3D;

        _uiDictionary[uiInstanceId] = uiGo;

        OpenChildren(prefabName, context, uiGo, uiInstanceId, ref rootEntity);

        if (parentEntity != null)
        {
            rootEntity?.ReplaceParentEntity(parentEntity);
        }

        return uiInstanceId;
    }

    private void OpenChildren(string prefabName, GameContext context, GameObject uiGo, int uiInstanceId, ref GameEntity rootEntity)
    {
        var componentInfo = context.uiConfig.UiInfos[prefabName];
        foreach (var component in componentInfo.Components)
        {
            var e = prefabName == component.ComponentPath ? rootEntity : context.CreateEntity();
            e.ReplaceName(component.ComponentName);
            e.ReplaceUiRootId(uiInstanceId);

            var componentGo = prefabName == component.ComponentPath ? uiGo : uiGo.transform.Find(component.ComponentPath.Substring(prefabName.Length + 1)).gameObject;

            foreach (var listener in component.Listener)
            {
                componentGo.AddComponent(ListenerList.dictionary[listener]);
            }

            if (component.Handle.Count > 0)
            {
                foreach (var handle in component.Handle)
                {
                    componentGo.AddComponent(HandleList.dictionary[handle]);
                }

                componentGo.Link(e);
                e.isLinked = true;
            }

            e.isAnomalyButton = component.AnomalyButton;
            
//            if (component.LinkEntity)
//            {
//                if(componentGo.GetComponent<Button>() != null)
//                {
//                    e.ReplaceClickState(false);
//                }
//
//                componentGo.Link(e);
//                e.isLinked = true;
//            }           

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
        UnlinkEntity(_uiDictionary[id].transform);
        GameObject.Destroy(_uiDictionary[id]);
    }

    private void UnlinkEntity(Transform tf)
    {
        for (int i = 0; i < tf.childCount; i++)
        {
            UnlinkEntity(tf.GetChild(i));
        }

        if (tf.gameObject.GetEntityLink() != null)
        {
            ((GameEntity) tf.gameObject.GetEntityLink().entity).isLinked = false;
            tf.gameObject.Unlink();
        }
    }
}