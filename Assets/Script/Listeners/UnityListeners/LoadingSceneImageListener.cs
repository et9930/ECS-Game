using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneImageListener : MonoBehaviour, IEventListener, IAnyLoadingSceneTextImageListener
{
    public GameEntity _entity;
    
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyLoadingSceneTextImageListener(this);
    }
    
    public void OnAnyLoadingSceneTextImage(GameEntity entity, string title, string text, string imagePath)
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePath);
    }
}
