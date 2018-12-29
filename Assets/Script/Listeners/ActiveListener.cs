using Entitas;
using UnityEngine;

public class ActiveListener : MonoBehaviour, IEventListener, IActiveListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddActiveListener(this);
    }

    public void OnActive(GameEntity entity, bool value)
    {
        gameObject.SetActive(value);
    }
}