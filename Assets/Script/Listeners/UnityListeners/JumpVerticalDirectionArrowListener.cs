using System;
using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class JumpVerticalDirectionArrowListener : MonoBehaviour, IEventListener, IAnyJumpAngleListener
{
    private GameEntity _entity;
    private GameEntity _playerEntity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyJumpAngleListener(this);
    }

    public void OnAnyJumpAngle(GameEntity entity, float Vertical, float Horizontal)
    {
        var rectTransform = GetComponent<RectTransform>();

        var newRotation = Quaternion.Euler(0, 0, (float)Vertical);
        rectTransform.localRotation = newRotation;
        var newPosition = new Vector3((float)Math.Cos(Vertical * Math.PI / 180) * 200, (float)Math.Sin(Vertical * Math.PI / 180) * 200);
        rectTransform.localPosition = newPosition;

        transform.parent.Find("JumpForceVerticalDirectionScale").localScale = Vertical > 90 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
    }
}