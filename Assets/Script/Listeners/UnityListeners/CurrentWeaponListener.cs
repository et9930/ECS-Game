using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponListener : MonoBehaviour, IEventListener, IAnyCurrentWeaponListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyCurrentWeaponListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyCurrentWeaponListener(this);
    }

    public void OnAnyCurrentWeapon(GameEntity entity, string value)
    {
        if (entity != _entity.parentEntity.value) return;

        var img = GetComponent<Image>();
        if (value != "")
        {
            img.color = Color.white;
            img.sprite = Resources.Load<Sprite>("Image/UI/NinjaItemIcon/" + value);
        }
        else
        {
            img.color = Color.clear;
        }
    }
}