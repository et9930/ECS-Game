using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNinjaItemListener : MonoBehaviour, IEventListener, IChooseNinjaItemInfoListener
{
    private bool hasRegistered = false;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddChooseNinjaItemInfoListener(this);
        hasRegistered = true;

    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

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