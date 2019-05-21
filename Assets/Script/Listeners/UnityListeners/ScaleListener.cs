using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class ScaleListener : MonoBehaviour, IEventListener, IScaleListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddScaleListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveScaleListener(this);
    }

    public void OnScale(GameEntity entity, Vector2 value)
    {
        transform.localScale = Utilities.ToUnityEngineVector2(value);
    }
}