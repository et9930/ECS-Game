using Entitas;
using UnityEngine;

public class ActiveListener : MonoBehaviour, IEventListener, IActiveListener
{
    private bool hasRegistered = false;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;
        _entity = (GameEntity) entity;
        _entity.AddActiveListener(this);
        _entity.ReplaceActive(gameObject.activeSelf);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if(!hasRegistered) return;
        hasRegistered = false;
        _entity.RemoveActiveListener(this);
    }

    public void OnActive(GameEntity entity, bool value)
    {
        gameObject.SetActive(value);
    }
}