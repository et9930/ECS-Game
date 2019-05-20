using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PingListener : MonoBehaviour, IEventListener, IAnyCurrentPingTimeListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyCurrentPingTimeListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyCurrentPingTimeListener(this);
    }

    public void OnAnyCurrentPingTime(GameEntity entity, int value)
    {
        GetComponent<Text>().text = "Ping: " + value + "ms";
    }
}