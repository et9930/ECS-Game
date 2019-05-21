using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class JumpForceListener : MonoBehaviour, IEventListener, IAnyJumpForceListener
{
    private bool hasRegistered = false;

    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddAnyJumpForceListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyJumpForceListener(this);
    }

    public void OnAnyJumpForce(GameEntity entity, float value)
    {
        GetComponent<Image>().fillAmount = value / 40000.0f;
    }
}