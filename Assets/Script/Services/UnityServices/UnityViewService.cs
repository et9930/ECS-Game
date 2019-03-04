using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;

public class UnityViewService : IViewService
{
    private GameObject viewRoot;

    public void InitializeViewRoot(string rootName)
    {
        viewRoot = GameObject.Find(rootName);

        if (viewRoot != null) return;

        viewRoot = new GameObject(rootName);
        Object.DontDestroyOnLoad(viewRoot);
    }

    public void InitializeView(Contexts contexts, IEntity entity, string objectName)
    {
        var viewGo = new GameObject(objectName);
        viewGo.transform.SetParent(viewRoot.transform);

        viewGo.transform.position = Utilities.Vector3PositionToVector2Position(((GameEntity) entity).position.value);
        viewGo.transform.localScale = Utilities.ToUnityEngineVector2(((GameEntity) entity).scale.value);

        var sr = viewGo.AddComponent<SpriteRenderer>();
        sr.sortingOrder = 0;
        sr.flipX = ((GameEntity) entity).toward.left;

        viewGo.AddComponent<HierarchyListener>();
        viewGo.AddComponent<PositionListener>();
        viewGo.AddComponent<ScaleListener>();
        viewGo.AddComponent<TowardListener>();

        var eventListeners = viewGo.GetComponents<IEventListener>();
        foreach (var listener in eventListeners)
        {
            listener.RegisterListeners(entity);
        }
    }

    public void LoadSprite(Contexts contexts, IEntity entity, string objectName, string assetName)
    {
        var viewTf = viewRoot.transform.Find(objectName);
        var viewGo = viewTf.gameObject;
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        viewSr.sprite = Resources.Load<Sprite>(assetName);
    }

    public Vector2 WorldPositionToScreenPosition(Vector3 worldPosition)
    {
        var unityWorldPosition = Utilities.Vector3PositionToVector2Position(worldPosition);
        var unityScreenPosition = Camera.main.WorldToScreenPoint(unityWorldPosition);
        return new Vector2(unityScreenPosition.x, unityScreenPosition.y);
    }

    public Vector2 ScreenSize => new Vector2(Screen.width, Screen.height);

    public Vector2 GetViewSize(string objectName)
    {
        var viewTf = viewRoot.transform.Find(objectName);
        var viewGo = viewTf.gameObject;
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        var spriteSize = viewSr.sprite.rect.size;
        var localSpriteSize = spriteSize / viewSr.sprite.pixelsPerUnit;
        var worldSize = localSpriteSize;
        worldSize.x *= viewTf.lossyScale.x;
        worldSize.y *= viewTf.lossyScale.y;
        return Utilities.ToSystemNumericsVector2(worldSize);
    }

    public Vector2 GetViewPivot(string objectName)
    {
        var viewTf = viewRoot.transform.Find(objectName);
        var viewGo = viewTf.gameObject;
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        var pivot = viewSr.sprite.pivot / viewSr.sprite.pixelsPerUnit;
        return Utilities.ToSystemNumericsVector2(pivot);
    }
}