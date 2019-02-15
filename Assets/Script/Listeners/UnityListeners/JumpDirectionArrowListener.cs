using System;
using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class JumpVerticalDirectionArrowListener : MonoBehaviour, IEventListener, IAnyMouseCurrentPositionListener
{
    private GameEntity _entity;
    private GameEntity _playerEntity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _context = Contexts.sharedInstance.game;
        _entity.AddAnyMouseCurrentPositionListener(this);
    }

    public void OnAnyMouseCurrentPosition(GameEntity entity, Vector2 value)
    {
        if (_playerEntity == null)
        {
            foreach (var e in _context.GetGroup(GameMatcher.Id))
            {
                if (e.id.value != _context.currentPlayerId.value) continue;
                if (e.isShadow) continue;

                _playerEntity = e;
            }
        }

        if (_playerEntity == null) return;

        var rectTransform = GetComponent<RectTransform>();

        var playerScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(_playerEntity.position.value);
        var mouseScreenPosition = _context.mouseCurrentPosition.value;

        var newRotation_z = Math.Atan((mouseScreenPosition.Y - playerScreenPosition.Y)/(mouseScreenPosition.X - playerScreenPosition.X)) * (180 / Math.PI);
        if (mouseScreenPosition.Y >= playerScreenPosition.Y)
        {
            if (mouseScreenPosition.X <= playerScreenPosition.X)
            {
                newRotation_z += 180;
            }
        }
        else
        {
            newRotation_z = mouseScreenPosition.X > playerScreenPosition.X ? 45 : 135;
        }

        _context.ReplaceJumpAngle((float)newRotation_z);

        var newRotation = Quaternion.Euler(0, 0, (float)newRotation_z);
        rectTransform.localRotation = newRotation;

        var newPosition = new Vector3((float)Math.Cos(newRotation_z * Math.PI / 180) * 200 + playerScreenPosition.X, (float)Math.Sin(newRotation_z * Math.PI / 180) * 200 + playerScreenPosition.Y);
        rectTransform.localPosition = newPosition;
    }
}