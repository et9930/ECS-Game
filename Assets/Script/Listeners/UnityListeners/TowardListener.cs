using Entitas;
using UnityEngine;

public class TowardListener : MonoBehaviour, IEventListener, ITowardListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddTowardListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveTowardListener(this);
    }

    public void OnToward(GameEntity entity, bool left)
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr)
        {
            sr.flipX = left;
        }
    }
}