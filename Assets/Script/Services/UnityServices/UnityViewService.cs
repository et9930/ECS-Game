using Entitas;
using UnityEngine;

public class UnityViewService : IViewService
{
    public void LoadAsset(Contexts contexts, IEntity entity, string assetName)
    {
        var viewGo = new GameObject();

        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        if (viewSr == null)
        {
            viewSr = viewGo.AddComponent<SpriteRenderer>();
        }
        viewSr.sprite = Resources.Load<Sprite>(assetName);

        var viewController = viewGo.GetComponent<IViewController>();
        if (viewController == null)
        {
            viewController = viewGo.AddComponent<UnityViewController>();
        }
        viewController.InitializeView(contexts, entity);

        viewGo.AddComponent<PositionListener>();
        var eventListeners = viewGo.GetComponents<IEventListener>();
        foreach (var listener in eventListeners)
        {
            listener.RegisterListeners(entity);
        }
    }
}