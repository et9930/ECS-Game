using Entitas;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class RotationListener : MonoBehaviour, IEventListener, IRotationListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddRotationListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveRotationListener(this);
    }

    public void OnRotation(GameEntity entity, Vector3 value)
    {
        transform.localRotation = Quaternion.Euler(Utilities.ToUnityEngineVector3(value));
    }
}