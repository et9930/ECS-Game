using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class JumpForceListener : MonoBehaviour, IEventListener, IAnyJumpForceListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyJumpForceListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyJumpForceListener(this);
    }

    public void OnAnyJumpForce(GameEntity entity, float value)
    {
        GetComponent<Image>().fillAmount = value / 40000.0f;
    }
}