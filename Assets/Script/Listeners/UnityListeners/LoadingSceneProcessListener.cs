using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneProcessListener : MonoBehaviour, IEventListener, IAnyLoadingSceneProcessListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddAnyLoadingSceneProcessListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyLoadingSceneProcessListener(this);
    }

    public void OnAnyLoadingSceneProcess(GameEntity entity, float value)
    {
        gameObject.GetComponent<Image>().fillAmount = value;
    }    
}