using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarValueListener : MonoBehaviour, IEventListener, IScrollBarValueListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddScrollBarValueListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveScrollBarValueListener(this);
    }

    public void OnScrollBarValue(GameEntity entity, float value)
    {
        GetComponent<Scrollbar>().value = value;
    }
}