using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNinjaItemListener : MonoBehaviour, IEventListener, IChooseNinjaItemInfoListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddChooseNinjaItemInfoListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveChooseNinjaItemInfoListener(this);
    }

    public void OnChooseNinjaItemInfo(GameEntity entity, AllocationNinjaItem value)
    {
        var toggleGroup = GameObject.Find("ChooseNinjaWindowNinjaList").GetComponent<ToggleGroup>();
        var toggle = GetComponent<Toggle>();
        toggle.group = toggleGroup;

        var headShot = transform.Find("Background/NinjaHeadShot").GetComponent<Image>();
        headShot.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + value.ninjaName + "HeadShot");

        //entity.ReplaceName(value.ninjaName);
    }
}