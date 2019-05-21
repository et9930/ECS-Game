using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneProcessListener : MonoBehaviour, IEventListener, IAnyLoadingSceneProcessListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity)entity;
        _entity.AddAnyLoadingSceneProcessListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyLoadingSceneProcessListener(this);
    }

    public void OnAnyLoadingSceneProcess(GameEntity entity, float value)
    {
        gameObject.GetComponent<Image>().fillAmount = value;
    }    
}