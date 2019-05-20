using Entitas;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class RotationListener : MonoBehaviour, IEventListener, IRotationListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddRotationListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveRotationListener(this);
    }

    public void OnRotation(GameEntity entity, Vector3 value)
    {
        transform.localRotation = Quaternion.Euler(Utilities.ToUnityEngineVector3(value));
    }
}