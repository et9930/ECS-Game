using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class QuickActionMenuItemListener : MonoBehaviour, IEventListener, IQuickActionItemConfigListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddQuickActionItemConfigListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveQuickActionItemConfigListener(this);
    }

    public void OnQuickActionItemConfig(GameEntity entity, QuickAction value)
    {
        var icon = transform.Find("QuickActionMenuItemIcon").GetComponent<Image>();
        var describe = transform.Find("QuickActionMenuItemDescribe").GetComponent<Text>();

        icon.sprite = Resources.Load<Sprite>("Image/UI/QuickAction/" + value.name);
        describe.text = value.describe;
    }
}