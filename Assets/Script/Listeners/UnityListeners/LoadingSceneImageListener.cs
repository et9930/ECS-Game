using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneImageListener : MonoBehaviour, IEventListener, IAnyLoadingSceneTextImageListener
{
    public GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddAnyLoadingSceneTextImageListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyLoadingSceneTextImageListener(this);
    }

    public void OnAnyLoadingSceneTextImage(GameEntity entity, string title, string text, string imagePath)
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePath);
    }
}
