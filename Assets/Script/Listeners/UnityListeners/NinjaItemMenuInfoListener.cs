using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class NinjaItemMenuInfoListener : MonoBehaviour, IEventListener, IAnyPointNinjaItemMenuItemListener
{
    private GameContext _context;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyPointNinjaItemMenuItemListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyPointNinjaItemMenuItemListener(this);
    }

    public void OnAnyPointNinjaItemMenuItem(GameEntity entity, string value)
    {
        var ninjaItemInfo = _context.ninjaItemAttributes.dic[value];

        // Ninja Item Name
        transform.Find("NinjaItemMenuInfoName").GetComponent<Text>().text = ninjaItemInfo.ninjaItemName;
        // Ninja Item Icon
        transform.Find("NinjaItemMenuInfoIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/UI/NinjaItemIcon/" + value);
        // Ninja Item Describe
        transform.Find("NinjaItemMenuInfoDescribe/NinjaItemMenuInfoDescribeText").GetComponent<Text>().text = ninjaItemInfo.ninjaItemDescribe;
        // Ninja Item Effect
        transform.Find("NinjaItemMenuInfoEffect/NinjaItemMenuInfoEffectText").GetComponent<Text>().text = ninjaItemInfo.ninjaItemEffect;

    }
}