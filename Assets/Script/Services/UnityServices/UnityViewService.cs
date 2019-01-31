using Entitas;
using UnityEngine;

public class UnityViewService : IViewService
{
    private GameObject viewRoot;

    public void InitializeViewRoot(string rootName)
    {
        viewRoot = GameObject.Find(rootName);
        if (viewRoot == null)
        {
            viewRoot = new GameObject(rootName);
            Object.DontDestroyOnLoad(viewRoot);
        }
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
}