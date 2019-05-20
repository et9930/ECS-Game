using Entitas;
using UnityEngine;

public class HierarchyListener : MonoBehaviour, IEventListener, IHierarchyListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddHierarchyListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveHierarchyListener(this);
    }

    public void OnHierarchy(GameEntity entity, float value)
    {
        var tmpPosition = transform.position;
        tmpPosition.z = value;
        transform.position = tmpPosition;
    }
}