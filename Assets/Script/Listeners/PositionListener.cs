using System.Numerics;
using Entitas;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddPositionListener(this);
    }

    public void OnPosition(GameEntity entity, System.Numerics.Vector3 value)
    {
        var tmp_z = transform.position.z;
        Vector3 tmpPosition = Utilities.Vector3PositionToVector2Position(value);
        tmpPosition.z = tmp_z;
        transform.position = tmpPosition;
    }
}