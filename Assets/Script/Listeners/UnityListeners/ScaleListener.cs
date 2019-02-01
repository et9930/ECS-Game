using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class ScaleListener : MonoBehaviour, IEventListener, IScaleListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddScaleListener(this);
    }

    public void OnScale(GameEntity entity, Vector2 value)
    {
        transform.localScale = Utilities.ToUnityEngineVector2(value);
    }
}