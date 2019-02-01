using Entitas;
using UnityEngine;

public class TowardListener : MonoBehaviour, IEventListener, ITowardListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddTowardListener(this);
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