using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class SelectTargetListener : MonoBehaviour, IEventListener, IParentEntityListener, ISelectTargetDistanceListener, ISelectTargetListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddParentEntityListener(this);
        _entity.AddSelectTargetDistanceListener(this);
        _entity.AddSelectTargetListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveParentEntityListener(this);
        _entity.RemoveSelectTargetDistanceListener(this);
        _entity.RemoveSelectTargetListener(this);
    }

    public void OnParentEntity(GameEntity entity, GameEntity value)
    {
        var icon = transform.Find("OutScreenSelectTargetIcon").GetComponent<Image>();
        var distance = transform.Find("OutScreenTargetDistance").GetComponent<Text>();
        if (value.hasUiRootId)
        {
            distance.text = _entity.selectTargetDistance.value + "m";
            
            icon.color = Color.white;
            icon.sprite = _entity.selectTarget.value.hasNinjaItemName
                ? Resources.Load<Sprite>("Image/UI/NinjaItemIcon/" + _entity.selectTarget.value.ninjaItemName.value)
                : Resources.Load<Sprite>("Image/UI/HeadShot/" + _entity.selectTarget.value.name.text + "HeadShot");

        }
        else
        {
            distance.text = "";
            icon.color = Color.clear;
        }
    }

    public void OnSelectTargetDistance(GameEntity entity, int value)
    {
       transform.Find("OutScreenTargetDistance").GetComponent<Text>().text = value > 0 ? value + "m" : "";
    }

    public void OnSelectTarget(GameEntity entity, GameEntity value)
    {
        var icon = transform.Find("OutScreenSelectTargetIcon").GetComponent<Image>();
        icon.color = Color.white;
        icon.sprite = _entity.selectTarget.value.hasNinjaItemName
            ? Resources.Load<Sprite>("Image/UI/NinjaItemIcon/" + value.ninjaItemName.value)
            : Resources.Load<Sprite>("Image/UI/HeadShot/" + value.name.text + "HeadShot");
        if (!_entity.parentEntity.value.hasUiRootId)
        {
            icon.color = Color.clear;
        }
    }
}