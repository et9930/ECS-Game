using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneTitleListener : MonoBehaviour, IEventListener, IAnyLoadingSceneTextImageListener
{
    private GameEntity _entity;
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
        gameObject.GetComponent<Text>().text = title;
    }
}