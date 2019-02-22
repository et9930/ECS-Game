using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarValueListener : MonoBehaviour, IEventListener, IScrollBarValueListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddScrollBarValueListener(this);
    }

    public void OnScrollBarValue(GameEntity entity, float value)
    {
        GetComponent<Scrollbar>().value = value;
    }
}