using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PingListener : MonoBehaviour, IEventListener, IAnyCurrentPingTimeListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddAnyCurrentPingTimeListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyCurrentPingTimeListener(this);
    }

    public void OnAnyCurrentPingTime(GameEntity entity, int value)
    {
        GetComponent<Text>().text = "Ping: " + value + "ms";
    }
}