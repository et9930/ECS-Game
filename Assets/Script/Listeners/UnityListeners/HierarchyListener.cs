using Entitas;
using UnityEngine;

public class HierarchyListener : MonoBehaviour, IEventListener, IHierarchyListener
{
    private bool hasRegistered = false;

    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddHierarchyListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveHierarchyListener(this);
    }

    public void OnHierarchy(GameEntity entity, float value)
    {
        var tmpPosition = transform.position;
        tmpPosition.z = value;
        transform.position = tmpPosition;
    }
}