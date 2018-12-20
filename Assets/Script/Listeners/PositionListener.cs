using System.Numerics;
using Entitas;
using UnityEngine;

public class PositionListener : MonoBehaviour, IEventListener, IPositionListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddPositionListener(this);
    }

    public void OnPosition(GameEntity entity, System.Numerics.Vector2 value)
    {
        transform.position = Utilities.ToUnityEngineVector2(value);
    }
}