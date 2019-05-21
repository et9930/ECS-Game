using Entitas;
using UnityEngine;

public class JumpHorizontalDirectionArrowListener : MonoBehaviour, IEventListener, IAnyJumpAngleListener
{
    private bool hasRegistered = false;

    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddAnyJumpAngleListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyJumpAngleListener(this);
    }

    public void OnAnyJumpAngle(GameEntity entity, float Vertical, float Horizontal)
    {
        var rectTransform = GetComponent<RectTransform>();
        var newPosition = Vector3.zero;
        var newRotation = Quaternion.Euler(Vector3.zero);
        var newScale = Vector3.one;

        if (Horizontal == 0.0f)
        {
            newPosition.x = 150;
            newScale.y = 0.5f;
        }
        else if (Horizontal == 45.0f)
        {
            newPosition.x = 86;
            newPosition.y = 22;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 15));
            newScale.x = 0.7f;
            newScale.y = 0.5f;
        }
        else if (Horizontal == 90.0f)
        {
            newPosition.y = 35;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            newScale.x = 0.25f;
        }
        else if (Horizontal == 135.0f)
        {
            newPosition.x = -86;
            newPosition.y = 22;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 165));
            newScale.x = 0.7f;
            newScale.y = 0.5f;
        }
        else if (Horizontal == 180.0f)
        {
            newPosition.x = -150;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 180));
            newScale.y = 0.5f;
        }
        else if (Horizontal == 225.0f)
        {
            newPosition.x = -86;
            newPosition.y = -22;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 195));
            newScale.x = 0.7f;
            newScale.y = 0.5f;
        }
        else if (Horizontal == 270.0f)
        {
            newPosition.y = -35;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 270));
            newScale.x = 0.25f;
        }
        else if (Horizontal == 315.0f)
        {
            newPosition.x = 86;
            newPosition.y = -22;
            newRotation = Quaternion.Euler(new Vector3(0, 0, 345));
            newScale.x = 0.7f;
            newScale.y = 0.5f;
        }

        rectTransform.localRotation = newRotation;
        rectTransform.localPosition = newPosition;
        rectTransform.localScale = newScale;
    }
}