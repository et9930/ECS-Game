using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneTextListener : MonoBehaviour, IEventListener, IAnyLoadingSceneTextImageListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyLoadingSceneTextImageListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyLoadingSceneTextImageListener(this);
    }

    public void OnAnyLoadingSceneTextImage(GameEntity entity, string title, string text, string imagePath)
    {
        gameObject.GetComponent<Text>().text = text;
    }
}