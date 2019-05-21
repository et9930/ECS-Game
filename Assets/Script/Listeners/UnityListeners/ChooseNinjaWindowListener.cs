using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNinjaWindowListener : MonoBehaviour, IEventListener, IAnyAllocationNinjaListener
{
    private bool hasRegistered = false;

    private GameEntity _entity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyAllocationNinjaListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyAllocationNinjaListener(this);
    }

    public void OnAnyAllocationNinja(GameEntity entity, SCAllocationNinja value)
    {
        var mapImage = transform.Find("ChooseNinjaWindowMapImage").GetComponent<Image>();
        mapImage.sprite = Resources.Load<Sprite>("Image/UI/MapImage/" + value.map.mapName);

        var mapName = transform.Find("ChooseNinjaWindowMapName").GetComponent<Text>();
        mapName.text = _context.mapConfig.list[value.map.mapName].Name;

        var battleType = transform.Find("ChooseNinjaWindowBattleType").GetComponent<Text>();
        switch (value.matchType)
        {
            case 1:
                battleType.text = "遭遇战";
                break;
            case 2:
                battleType.text = "攻防战";
                break;
            case 3:
                battleType.text = "争夺战";
                break;
            default:
                battleType.text = "未知";
                break;
        }
        
    }
}